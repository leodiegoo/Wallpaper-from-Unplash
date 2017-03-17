using ChangeWallpaperUnplash.Backend;
using System;
using System.Windows.Forms;

namespace ChangeWallpaperUnplash.Front
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
            Buscar();
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

        private void timer_Tick(object sender, EventArgs e)
        {
            Buscar();
        }

        private async void Buscar()
        {
            lblMsg.Text = "Buscando imagem...";
            var result = await Get.GetAsync();
            if (result)
                lblMsg.Text = "Papel de parede alterado, próxima em breve :)";
        }

    }
}
