using InTune.Domain;
using IntuneChat.Model;
using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intune.Desktop
{
    //public class ChatHubManager
    //{
    //    private string _userName;
    //    private string _userEmail;

    //    private const string chatServerUri = @"http://intunechat.apphb.com/";
    //    private HubConnection _hubConnection = null;
    //    private IHubProxy _hubProxy = null;

    //    public ChatHubManager(string userName, string userEmail)
    //    {
    //        _userName = userName;
    //        _userEmail = userEmail;
    //        connectAsync();
    //    }

    //    private async void connectAsync()
    //    {
    //        _hubConnection = new HubConnection(chatServerUri);
    //        fillHubConnectionHeaderInfo();
    //        _hubProxy = _hubConnection.CreateHubProxy("ChatHub");
    //        _hubProxy.On<ChatMessage>("AddComment", (chatMessage) =>
    //                        this.Invoke((Action)(() => processMessage(chatMessage))));
    //        try
    //        {
    //            await _hubConnection.Start();
    //        }
    //        catch (Exception ex)
    //        {
    //            MessageBox.Show(ex.Message);
    //        }
    //    }

    //    private void fillHubConnectionHeaderInfo()
    //    {
    //        var userName = new KeyValuePair<string, string>("UserName", _userName);
    //        var userEmail = new KeyValuePair<string, string>("UserEmail", _userEmail);
    //        _hubConnection.Headers.Add(userName);
    //        _hubConnection.Headers.Add(userEmail);
    //    }
    //}
}
