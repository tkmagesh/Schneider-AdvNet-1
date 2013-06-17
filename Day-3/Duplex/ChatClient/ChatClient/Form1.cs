using System.ServiceModel;
using ChatClient.ServiceProxies;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ChatClient
{
    public partial class Form1 : Form, IChatServiceCallback
    {
        private ChatServiceClient chatService;

        public Form1()
        {
            InitializeComponent();
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            var name = "user-" + Guid.NewGuid().ToString();
            chatService = new ChatServiceClient(new InstanceContext(this));
            chatService.Login(name);
        }

        public void ReceiveMessage(string message)
        {
            lstMessages.Items.Add(message);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            chatService.SendMessage(this.txtMessage.Text);
        }
    }
}
