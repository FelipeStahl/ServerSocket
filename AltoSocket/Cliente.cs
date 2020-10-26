using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltoSocket
{
    public class Cliente : IEventosConexao
    {
        public event InfoConexaoHandler InfoConexao;
        public event TransferEventHandler Recebendo;
        public event TransferEventHandler ProgressoAlterado;
        public event TransferEventHandler Interrompido;
        public event TransferEventHandler Completo;

        public TransferClient transferClient { get; private set; }
        public string pastaDownload { get; set; }

        public Cliente(string diretorio)
        {
            pastaDownload = diretorio;

            if (!Directory.Exists(pastaDownload))
            {
                Directory.CreateDirectory(pastaDownload);
            }
        }

        public void Iniciar(String ip, int porta)
        {
            if (transferClient == null)
            {
                transferClient = new TransferClient();
                transferClient.Connect(ip, porta, connectCallback);
            }
            else
            {
                transferClient.Close();
                transferClient = null;
            }
        }

        public void Fechar()
        {
            deregisterEvents();
        }

        public void enviarArquivo(String caminhoArquivo, String pasta = null)
        {
            if (transferClient == null)
                return;
            try
            {
                if (pasta == null)
                {
                    transferClient.QueueTransfer(caminhoArquivo);
                }
                else
                {
                    transferClient.QueueTransfer(caminhoArquivo, pasta);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        private void connectCallback(object sender, string error)
        {
            if (error != null)
            {
                InfoConexao?.Invoke(false, error, null);
                transferClient.Close();
                transferClient = null;
                return;
            }
            registerEvents();
            transferClient.OutputFolder = pastaDownload;
            transferClient.Run();
            InfoConexao?.Invoke(true, "Conexão realizada com sucesso! / " + transferClient.EndPoint.Address.ToString(), null);
        }

        private void registerEvents()
        {
            transferClient.Complete += transferClient_Complete;
            transferClient.Disconnected += transferClient_Disconnected;
            transferClient.ProgressChanged += transferClient_ProgressChanged;
            transferClient.Queued += transferClient_Queued;
            transferClient.Stopped += transferClient_Stopped;
        }

        void transferClient_Stopped(object sender, TransferQueue queue)
        {
            Interrompido?.Invoke(sender, queue);
        }

        void transferClient_Queued(object sender, TransferQueue queue)
        {
            Recebendo?.Invoke(sender, queue);
            if (queue.Type == QueueType.Download)
            {
                transferClient.StartTransfer(queue);
            }
        }

        void transferClient_ProgressChanged(object sender, TransferQueue queue)
        {
            ProgressoAlterado?.Invoke(sender, queue);
        }

        void transferClient_Disconnected(object sender, EventArgs e)
        {
            InfoConexao?.Invoke(false, "Cliente desconectado.", null);
            deregisterEvents();
            transferClient = null;
        }

        void transferClient_Complete(object sender, TransferQueue queue)
        {
            Completo?.Invoke(sender, queue);
        }

        private void deregisterEvents()
        {
            if (transferClient == null)
                return;
            transferClient.Complete -= transferClient_Complete;
            transferClient.Disconnected -= transferClient_Disconnected;
            transferClient.ProgressChanged -= transferClient_ProgressChanged;
            transferClient.Queued -= transferClient_Queued;
            transferClient.Stopped -= transferClient_Stopped;
        }
    }
}
