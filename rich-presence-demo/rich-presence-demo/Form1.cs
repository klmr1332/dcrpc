using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rich_presence_demo
{
    public partial class Form1 : Form
    {
        private RichPresencer.ehandler events;
        private RichPresencer.prsnc presence;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.events = default(RichPresencer.ehandler);
            RichPresencer.Initialize("client id", ref this.events, true, null);
            this.events = default(RichPresencer.ehandler);
            RichPresencer.Initialize("client id", ref this.events, true, null);
            this.presence.details = rpcdetails.Text;
            this.presence.state = rpcstate.Text;
            this.presence.largeImageKey = rpclimgk.Text;
            this.presence.largeImageText = rpclimgt.Text;
            this.presence.smallImageKey = rpcsmallimgk.Text;
            this.presence.smallImageText = rpcsmallimgt.Text;
            this.presence.matchSecret = rpcmatchS.Text;
            this.presence.joinSecret = rpcjoinS.Text;
            RichPresencer.UpdatePresence(ref this.presence);
        }
    }
}
