using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Lalogo.InstantPublisher
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();

            var assembly = Assembly.GetAssembly(GetType());
            VersionLabel.Text = assembly.GetName().Version.ToString();
            AuthorLabel.Text = assembly
                .GetCustomAttributes(typeof(AssemblyCompanyAttribute), false)
                .OfType<AssemblyCompanyAttribute>()
                .FirstOrDefault()?
                .Company;
            CopyrightLabel.Text = assembly.GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false)
                .OfType<AssemblyCopyrightAttribute>()
                .FirstOrDefault()?
                .Copyright;
        }

        private void GitHubLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/la-lo-go/instant-publisher");
        }

        private void GitHubLink_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/la-lo-go/instant-publisher");

        }

        private void BugReportLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/la-lo-go/instant-publisher/issues/new");
        }
    }
}
