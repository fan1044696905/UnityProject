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
        protected override void OnOperationRequest(OperationRequest operationRequest, SendParameters sendParameters)
        {
            switch (operationRequest.OperationCode)
            {
                case 1:
                    MyGameServer.log.Info("客户端发起了请求");
                    
                    Dictionary<byte, object> data = operationRequest.Parameters;//接收客户端发来的请求
                    object intValue;
                    data.TryGetValue(1,out intValue);
                    object strValue;
                    data.TryGetValue(2, out strValue);
                    MyGameServer.log.Info("传递的字典参数数据为"+intValue.ToString()+"   "+strValue.ToString());

                    //将数据返回给客户端
                    OperationResponse opResponse = new OperationResponse(1);
                    Dictionary<byte,object> data2 = new Dictionary<byte,object>();
                    data2.Add(1, 1000);
                    data2.Add(2, "一招败敌，蔺无双胜利！！！");
                    opResponse.SetParameters(data2);
                    SendOperationResponse(opResponse,sendParameters);//给客户端一个相应

                    EventData ed = new EventData(1);
                    Dictionary<byte,object> data3 = new Dictionary<byte,object>();
                    data3.Add(1, 1000);
                    data3.Add(2, "蔺无双为练峨眉报仇而来！！！");
                    ed.Parameters = data3;
                    SendEvent(ed,new SendParameters());
                    break;
                case 2:
                    break;
                default:
                    break;
            }
        }
    }
}
