using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using Microsoft.Web.WebSockets;
namespace UsingWebSockets
{
    public class MicrosoftWebSockets : WebSocketHandler
    {
        private static WebSocketCollection clients = new WebSocketCollection();
        private string name;

        public override void OnOpen()
        {
            name = this.WebSocketContext.QueryString["chatName"];
            clients.Add(this);
            clients.Broadcast(name + " entrou na sala.");
        }
        
        public override void OnMessage(string message)
        {

            //clients.FirstOrDefault(x =>x.);
            clients.Broadcast(string.Format("{0} disse: {1}", name, message));
        }
        
        public override void OnClose()
        {
            clients.Remove(this);
            clients.Broadcast(string.Format("{0} saiu da sala.", name));
        }

    }
}