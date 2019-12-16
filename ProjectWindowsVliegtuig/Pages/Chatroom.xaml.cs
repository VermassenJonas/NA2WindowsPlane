using ProjectWindowsVliegtuig.Model;
using ProjectWindowsVliegtuig.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ProjectWindowsVliegtuig.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Chatroom : Page
    {
        public MessageVM Messages { get; set; }
        public Chatroom()
        {
            Messages = new MessageVM();
            this.DataContext = Messages;
            this.InitializeComponent();
        }

        public void AddMessage()
        {
            Message message = new Message()
            {
                Alignment = "Left",
                Content = MessageInput.Text,
                Sender = "Jonas",
                Sent = DateTime.Now
            };
            Messages.MessageList.Add(message);
        } 
    }
}
