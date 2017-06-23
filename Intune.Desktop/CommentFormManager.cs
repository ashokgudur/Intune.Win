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
    public class CommentFormManager : IDisposable
    {
        private IDictionary<string, FComment> _instances;
        private IHubProxy _hubProxy;

        public CommentFormManager(IHubProxy hubProxy)
        {
            _hubProxy = hubProxy;
            _instances = new Dictionary<string, FComment>();
        }

        public void SendMessage(ChatMessage chatMessage)
        {
            _hubProxy.Invoke("SendComment", chatMessage);
        }

        public bool ProcessChatMessage(ChatMessage chatMessage)
        {
            FComment form = null;
            var found = _instances.TryGetValue(chatMessage.GetCommentKey(), out form);
            if (found)
                form.DisplayComment(chatMessage);

            return found;
        }

        public FComment GetContactCommentForm(Contact contact)
        {
            FComment instance = null;
            var key = composeKey(CommentType.Contact, contact.ContactUserId);
            var found = _instances.TryGetValue(key, out instance);
            if (found)
                return instance;

            instance = getFormInstance();
            instance.ToUser = IntuneService.GetUserById(contact.ContactUserId);
            _instances.Add(key, instance);
            return instance;
        }

        public FComment GetAccountCommentForm(Account account)
        {
            FComment instance = null;
            var key = composeKey(CommentType.Account, account.Id);
            var found = _instances.TryGetValue(key, out instance);
            if (found)
                return instance;

            instance = getFormInstance();
            instance.Account = account;
            _instances.Add(key, instance);
            return instance;
        }

        public FComment GetAccountEntryCommentForm(Account account, Entry entry)
        {
            FComment instance = null;
            var key = composeKey(CommentType.Entry, entry.Id);
            var found = _instances.TryGetValue(key, out instance);
            if (found)
                return instance;

            instance = getFormInstance();
            instance.Account = account;
            instance.Entry = entry;
            _instances.Add(key, instance);
            return instance;
        }

        private string composeKey(CommentType type, int id)
        {
            return string.Format("{0}-{1}", type, id);
        }

        private FComment getFormInstance()
        {
            var instance = new FComment();
            instance.ByUser = Session.CurrentUser;
            return instance;
        }

        public void RemoveForm(FComment instance)
        {
            string key = "";
            if (instance.Entry != null)
                key = composeKey(CommentType.Entry, instance.Entry.Id);
            else if (instance.Account != null)
                key = composeKey(CommentType.Account, instance.Account.Id);
            else
                key = composeKey(CommentType.Contact, instance.ToUser.Id);

            _instances.Remove(key);
        }

        public void Dispose()
        {
            foreach (var instance in _instances)
                instance.Value.Dispose();

            _instances = null;
        }
    }
}
