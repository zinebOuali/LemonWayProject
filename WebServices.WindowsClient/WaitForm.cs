using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebServices.WindowsClient
{
	public partial class WaitForm : Form
	{
		public Action Worker { get; set; }
		public WaitForm(Action worker)
		{
			InitializeComponent();
			if (worker == null)
				throw new ArgumentNullException();
			Worker = worker;

		}
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			Task.Factory.StartNew(Worker).ContinueWith(t => { this.Close(); }, TaskScheduler.FromCurrentSynchronizationContext());
		}
	}
}
