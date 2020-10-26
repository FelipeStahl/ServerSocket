using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltoSocket
{
    public delegate void TransferEventHandler(object sender, TransferQueue queue);
    public delegate void ConnectCallback(object sender, string error);
    public delegate void InfoConexaoHandler(Boolean conectado, string mensagem, TransferClient transferClient);
    internal delegate void SocketAcceptedHandler(object sender, SocketAcceptedEventArgs e);

    public interface IEventosConexao
    {
        event InfoConexaoHandler InfoConexao;
        event TransferEventHandler Recebendo;
        event TransferEventHandler ProgressoAlterado;
        event TransferEventHandler Interrompido;
        event TransferEventHandler Completo;
    }
}
