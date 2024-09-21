using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfBlazorHybridDotNet8.Services
{
    public class WpfInteractionService
    {
        public event Action<string>? OnMessageSent;

        public void SendMessageToWPF(string message)
        {
            OnMessageSent?.Invoke(message);
        }
    }
}
