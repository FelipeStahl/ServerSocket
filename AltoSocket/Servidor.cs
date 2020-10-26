using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AltoSocket
{
    public class Servidor : IEventosConexao
    {
        private Listener listener;
        private Dictionary<IPEndPoint, TransferClient> transferClients;
        public string pastaDownload { get; set; }
        private bool serverRunning;
        private int _porta;

        public event InfoConexaoHandler InfoConexao;
        public event TransferEventHandler Recebendo;
        public event TransferEventHandler ProgressoAlterado;
        public event TransferEventHandler Interrompido;
        public event TransferEventHandler Completo;

        public Servidor(string diretorio)
        {
            pastaDownload = diretorio;

            if (!Directory.Exists(pastaDownload))
            {
                Directory.CreateDirectory(pastaDownload);
            }
        }

        public void Iniciar(int porta)
        {
            if (serverRunning)
                return;
            _porta = porta;
            transferClients = new Dictionary<IPEndPoint, TransferClient>();
            listener = new Listener();
            listener.Accepted += listener_Accepted;
            serverRunning = true;
            try
            {
                listener.Start(porta);
                InfoConexao?.Invoke(false, "Aguardando cliente...", null);
            }
            catch
            {
                serverRunning = false;
                InfoConexao?.Invoke(false, "Conexão inválida", null);
                throw;
            }
        }

        public void Fechar()
        {
            if (!serverRunning)
                return;
            if (transferClients != null)
            {
                foreach (var item in transferClients)
                {
                    deregisterEvents(item.Value.EndPoint);
                    item.Value.Close();
                }
                transferClients = null;
            }
            listener.Stop();
            InfoConexao?.Invoke(false, "Servidor desconectado.", null);
            serverRunning = false;


        }

        public void enviarArquivo(String caminhoArquivo, IPEndPoint ipEndPoint, String pasta = null)
        {
            if (!transferClients.ContainsKey(ipEndPoint))
                return;
            try
            {
                if (pasta == null)
                {
                    transferClients[ipEndPoint].QueueTransfer(caminhoArquivo);
                }
                else
                {
                    transferClients[ipEndPoint].QueueTransfer(caminhoArquivo, pasta);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        void listener_Accepted(object sender, SocketAcceptedEventArgs e)
        {
            //listener.Stop();
            TransferClient transferClient = new TransferClient(e.Accepted);
            transferClient.OutputFolder = pastaDownload;
            transferClient.Run();
            transferClients.Add(transferClient.EndPoint, transferClient);
            registerEvents(transferClient.EndPoint);
            InfoConexao?.Invoke(true, "Conexão realizada com sucesso! / " + transferClient.EndPoint.Address.ToString(), transferClient);
        }

        private void registerEvents(IPEndPoint ipEndPoint)
        {
            transferClients[ipEndPoint].Complete += transferClient_Complete;
            transferClients[ipEndPoint].Disconnected += transferClient_Disconnected;
            transferClients[ipEndPoint].ProgressChanged += transferClient_ProgressChanged;
            transferClients[ipEndPoint].Queued += transferClient_Queued;
            transferClients[ipEndPoint].Stopped += transferClient_Stopped;
        }

        void transferClient_Stopped(object sender, TransferQueue queue)
        {
            Interrompido?.Invoke(sender, queue);
        }

        void transferClient_Queued(object sender, TransferQueue queue)
        {
            Recebendo?.Invoke(sender, queue);
            TransferClient transferClient = (TransferClient)sender;
            if (queue.Type == QueueType.Download)
            {
                transferClients[transferClient.EndPoint].StartTransfer(queue);
            }
        }

        void transferClient_ProgressChanged(object sender, TransferQueue queue)
        {
            ProgressoAlterado?.Invoke(sender, queue);
        }

        void transferClient_Disconnected(object sender, EventArgs e)
        {

            TransferClient transferClient = (TransferClient)sender;
            deregisterEvents(transferClient.EndPoint);

            InfoConexao?.Invoke(false, "Cliente desconectado.", transferClient);

            if (serverRunning)
            {
                listener.Start(_porta);
            }
        }

        void transferClient_Complete(object sender, TransferQueue queue)
        {
            Completo?.Invoke(sender, queue);
        }

        private void deregisterEvents(IPEndPoint ipEndPoint)
        {
            if (!transferClients.ContainsKey(ipEndPoint))
                return;
            transferClients[ipEndPoint].Complete -= transferClient_Complete;
            transferClients[ipEndPoint].Disconnected -= transferClient_Disconnected;
            transferClients[ipEndPoint].ProgressChanged -= transferClient_ProgressChanged;
            transferClients[ipEndPoint].Queued -= transferClient_Queued;
            transferClients[ipEndPoint].Stopped -= transferClient_Stopped;
        }
    }
}
