namespace simTraffic
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        private void startButtonClick(object sender, EventArgs e)
        {
            otherClass.trafficView trafficView = new otherClass.trafficView();
            trafficView.Show();
        }
    }
}