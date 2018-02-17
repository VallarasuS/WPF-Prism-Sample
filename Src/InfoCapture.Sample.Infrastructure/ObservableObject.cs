using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace InfoCapture.Sample.Infrastructure
{
	public class ObservableObject : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		public void RaisePropertyChanged([CallerMemberName] string propertyName = "")
		{
			var handler = PropertyChanged;

			if (handler == null) return;

			handler(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}