using AltoSocket;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exemplo
{
    public partial class Form1 : Form
    {
        Servidor servidor;
        Cliente cliente;
        public Form1()
        {
            InitializeComponent();
            listBox1.DisplayMember = "nome";
            listBox1.ValueMember = "ip";
            txIp.Text = getLocalIPAddress();
        }

        private string getLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        private void btServidor_Click(object sender, EventArgs e)
        {
            servidor = new Servidor("ServerDownload");
            registrarEvento(servidor);
            servidor.Iniciar(int.Parse(txPorta.Text.Trim()));
        }

        private void btCliente_Click(object sender, EventArgs e)
        {
            iniciarCliente();
        }

        #region "Registros"
        private void iniciarCliente()
        {
            cliente = new Cliente("ClienteDownload");
            registrarEvento(cliente);
            cliente.Iniciar(txIp.Text.Trim(), int.Parse(txPorta.Text.Trim()));
        }

        public void registrarEvento(IEventosConexao eventoObjeto)
        {
            eventoObjeto.InfoConexao += infoConexao;
            eventoObjeto.Completo += transferClient_Complete;
            eventoObjeto.ProgressoAlterado += transferClient_ProgressChanged;
            eventoObjeto.Recebendo += transferClient_Queued;
            eventoObjeto.Interrompido += transferClient_Stopped;
        }

        public void desregistrarEvento(IEventosConexao eventoObjeto)
        {
            eventoObjeto.InfoConexao -= infoConexao;
            eventoObjeto.Completo -= transferClient_Complete;
            eventoObjeto.ProgressoAlterado -= transferClient_ProgressChanged;
            eventoObjeto.Recebendo -= transferClient_Queued;
            eventoObjeto.Interrompido -= transferClient_Stopped;
        }
        #endregion

        #region "Eventos de Conexão"
        public void infoConexao(bool conectado, string mensagem, TransferClient transferClient)
        {
            if (InvokeRequired)
            {
                Invoke(new InfoConexaoHandler(infoConexao), conectado, mensagem, transferClient);
                return;
            }
            if (!conectado)
            {
                if (cliente != null)
                {
                    desregistrarEvento(cliente);
                    cliente = null;
                    iniciarCliente();
                }
                //if (servidor != null)
                //    desregistrarEvento(servidor);
                //Close every transfer
                foreach (ListViewItem item in lstTransfers.Items)
                {
                    TransferQueue queue = (TransferQueue)item.Tag;
                    queue.Close();
                }
                //Clear the listview
                lstTransfers.Items.Clear();
                progressOverall.Value = 0;
                if (transferClient != null)
                    listBox1.Items.Remove(transferClient);
            }
            else
            {
                if (transferClient != null)
                    listBox1.Items.Add(transferClient);
            }
            lbInfoConexao.Text = mensagem;
        }

        public void transferClient_Stopped(object sender, TransferQueue queue)
        {
            if (InvokeRequired)
            {
                Invoke(new TransferEventHandler(transferClient_Stopped), sender, queue);
                return;
            }
            lstTransfers.Items[queue.ID.ToString()].Remove();
        }

        public void transferClient_Queued(object sender, TransferQueue queue)
        {
            if (InvokeRequired)
            {
                Invoke(new TransferEventHandler(transferClient_Queued), sender, queue);
                return;
            }

            ListViewItem i = new ListViewItem();
            i.Text = queue.ID.ToString();
            i.SubItems.Add(queue.Filename);
            i.SubItems.Add(queue.Type == QueueType.Download ? "Download" : "Upload");
            i.SubItems.Add("0%");
            i.Tag = queue;
            i.Name = queue.ID.ToString();
            lstTransfers.Items.Add(i);
            i.EnsureVisible();
        }

        public void transferClient_ProgressChanged(object sender, TransferQueue queue)
        {
            if (InvokeRequired)
            {
                Invoke(new TransferEventHandler(transferClient_ProgressChanged), sender, queue);
                return;
            }

            //Set the progress cell to our current progress.
            lstTransfers.Items[queue.ID.ToString()].SubItems[3].Text = queue.Progress + "%";
        }

        public void transferClient_Complete(object sender, TransferQueue queue)
        {

            System.Media.SystemSounds.Asterisk.Play();
        }
        #endregion

        private void btEnviarArquivo_Click(object sender, EventArgs e)
        {
            enviarArquivo();
        }

        private void enviarArquivo()
        {
            if (cliente == null && servidor == null)
                return;
            if (listBox1.SelectedIndex == -1 && servidor != null)
            {
                MessageBox.Show("Selecione um destinatário.");
                return;
            }
            //Get the user desired files to send
            using (OpenFileDialog o = new OpenFileDialog())
            {
                o.Filter = "All Files (*.*)|*.*";
                o.Multiselect = true;

                if (o.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    foreach (string file in o.FileNames)
                    {
                        if (cliente != null)
                        {
                            try
                            {
                                cliente.enviarArquivo(file);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }

                        }
                        else
                        {
                            try
                            {
                                TransferClient transferClient = (TransferClient)listBox1.Items[listBox1.SelectedIndex];
                                servidor.enviarArquivo(file, transferClient.EndPoint);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }

                        }

                    }
                }
            }
        }

        private void btnStopTransfer_Click(object sender, EventArgs e)
        {
            //if (InvokeRequired)
            //{
            //    Invoke(new TransferEventHandler(transferClient_Stopped), sender, queue);
            //    return;
            //}
            ////Remove the stopped transfer from view.
            //lstTransfers.Items[queue.ID.ToString()].Remove();
        }
    }
}
