using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Photon.SocketServer;
namespace MyGameServer
{
    class ClientPeer:Photon.SocketServer.ClientPeer
    {
        public ClientPeer(InitRequest initRequest):base(initRequest)
        {

        }

        //处理客户端断开连接的后续工作
        protected override void OnDisconnect(PhotonHostRuntimeInterfaces.DisconnectReason reasonCode, string reasonDetail)
        {
            
        }

        //处理客户端的请求
        protected override void OnOperationRequest(Photon.SocketServer.OperationRequest operationRequest, Photon.SocketServer.SendParameters sendParameters)
        {
           
        }
    }
}
