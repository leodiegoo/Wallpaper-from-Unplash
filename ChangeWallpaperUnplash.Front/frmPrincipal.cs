using ChangeWallpaperUnplash.Backend;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChangeWallpaperUnplash.Front
{
    public partial class frmPrincipal : Form
    {
        private Timer timerFirst = new Timer() { Interval = 1000 };
        public frmPrincipal()
        {
            InitializeComponent();
            timerFirst.Tick += timerFirst_Tick;
            timerFirst.Start();
            timer.Start();
        }

        private void frmPrincipal_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon.Visible = true;
                notifyIcon.ShowBalloonTip(1000);
            }
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            notifyIcon.Visible = false;
        }

        private async void timer_Tick(object sender, EventArgs e)
        {
            await Buscar();
        }
        private async Task Buscar()
        {
            lblMsg.Text = "Buscando imagem...";
            var result = await Get.GetAsync();
            if (result)
                lblMsg.Text = "Papel de parede alterado, próximo em breve :)";
        }

        private async void timerFirst_Tick(object sender, EventArgs e)
        {
            if (timerFirst.Enabled)
                await Buscar();            
            else            
                timerFirst.Stop();                
            timerFirst.Enabled = false;
        }
    }
}
