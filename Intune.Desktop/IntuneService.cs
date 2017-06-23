using InTune.Domain;
using System;
using System.Net;
using System.Net.Http;

namespace Intune.Desktop
{
    public static class IntuneService
    {
        private const string _intuneServerUri = "";

        private static string intuneServerUri
        {
            get
            {
#if DEBUG
                return StringCipher.Decrypt(@"/96yJXE8eXT1Tlb9kWLC8yMNlx/vFKcEAugaoUefpyU=", @"SonyVaioZSeriesVPCZ1");
                //return @"http://localhost:58187/";
#else
                return StringCipher.Decrypt(@"Y9WMM7Jr5uw8o4oWRRKCf1258EGAafpJ24oLfC0Xx/A=", @"SonyVaioZSeriesVPCZ1");
#endif
            }
        }

        public static User RegisterUser(User user)
        {
            string userRegisterApiUri = @"api/user/register";
            var client = new HttpClient();
            client.BaseAddress = new Uri(intuneServerUri);
            var response = client.PostAsJsonAsync(userRegisterApiUri, user).Result;
            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception("Cannot register user.");

            var result = response.Content.ReadAsAsync<User>().Result;
            return result;
        }

        public static User UpdateUser(User user)
        {
            string userRegisterApiUri = @"api/user/update";
            var client = new HttpClient();
            client.BaseAddress = new Uri(intuneServerUri);
            var response = client.PostAsJsonAsync(userRegisterApiUri, user).Result;
            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception("Cannot save user.");

            var result = response.Content.ReadAsAsync<User>().Result;
            return result;
        }

        public static void ForgotPassword(string email)
        {
            string userForgotPasswordApiUri = @"api/user/forgotpassword";
            string userForgotPasswordApiUriString = string.Format("{0}{1}{2}", userForgotPasswordApiUri, "/?email=", email);
            var client = new HttpClient();
            client.BaseAddress = new Uri(intuneServerUri);
            var response = client.GetAsync(userForgotPasswordApiUriString).Result;
            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception("Cannot send your password.\n\nYour email address might not be correct or not registered");
        }

        public static User Login(string email, string password)
        {
            var user = new User { Email = email, Password = password };
            string userLoginApiUri = @"api/user/signin";
            var client = new HttpClient();
            client.BaseAddress = new Uri(intuneServerUri);
            var response = client.PostAsJsonAsync(userLoginApiUri, user).Result;
            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception("Cannot login.");

            var result = response.Content.ReadAsAsync<User>().Result;
            return result;
        }

        public static User GetUserById(int userId)
        {
            string usersApiUri = @"api/user/userbyId";
            string usersApiUriString = string.Format("{0}{1}{2}", usersApiUri, "/?userId=", userId);
            var client = new HttpClient();
            client.BaseAddress = new Uri(intuneServerUri);
            var response = client.GetAsync(usersApiUriString).Result;
            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception("Cannot Read Data");

            var result = response.Content.ReadAsAsync<User>().Result;
            return result;
        }

        public static Contact[] GetAllContacts()
        {
            string userContactsApiUri = @"api/contact/allcontacts";
            string userContactsApiUriString = string.Format("{0}{1}{2}",
                                    userContactsApiUri, "/?userId=", Session.CurrentUser.Id);
            var client = new HttpClient();
            client.BaseAddress = new Uri(intuneServerUri);
            var response = client.GetAsync(userContactsApiUriString).Result;
            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception("Cannot Read Data");

            var result = response.Content.ReadAsAsync<Contact[]>().Result;
            return result;
        }

        public static Account[] GetAllAccounts()
        {
            return GetAllAccounts(0);
        }

        public static Account[] GetAllAccounts(int contactId)
        {
            string accountApiUri = @"api/account/allaccounts";
            string param = string.Format("/?userId={0}&contactId={1}", Session.CurrentUser.Id, contactId);
            string accountApiUriString = string.Format("{0}{1}", accountApiUri, param);
            var client = new HttpClient();
            client.BaseAddress = new Uri(intuneServerUri);
            var response = client.GetAsync(accountApiUriString).Result;
            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception("Cannot Read Data");

            var result = response.Content.ReadAsAsync<Account[]>().Result;
            return result;
        }

        public static Contact AddContact(Contact contact)
        {
            string accountApiUri = @"api/contact/create";
            var client = new HttpClient();
            client.BaseAddress = new Uri(intuneServerUri);
            var response = client.PostAsJsonAsync(accountApiUri, contact).Result;
            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception("Cannot Add Contact");

            var result = response.Content.ReadAsAsync<Contact>().Result;
            return result;
        }

        public static Contact UpdateContact(Contact contact)
        {
            string accountApiUri = @"api/contact/update";
            var client = new HttpClient();
            client.BaseAddress = new Uri(intuneServerUri);
            var response = client.PostAsJsonAsync(accountApiUri, contact).Result;
            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception("Cannot Update Contact");

            var result = response.Content.ReadAsAsync<Contact>().Result;
            return result;
        }

        public static Account AddAccount(Account account)
        {
            string accountApiUri = @"api/account/create";
            var client = new HttpClient();
            client.BaseAddress = new Uri(intuneServerUri);
            var response = client.PostAsJsonAsync(accountApiUri, account).Result;
            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception("Cannot Add Account.");

            var result = response.Content.ReadAsAsync<Account>().Result;
            return result;
        }

        public static Account[] GetContactAccounts(int contactId)
        {
            string contactAccountsApiUri = @"api/account/contact/accounts";
            string contactAccountsApiUriString = string.Format("{0}{1}{2}", contactAccountsApiUri, "/?contactId=", contactId);
            var client = new HttpClient();
            client.BaseAddress = new Uri(intuneServerUri);
            var response = client.GetAsync(contactAccountsApiUriString).Result;
            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception("Cannot Read Data");

            var result = response.Content.ReadAsAsync<Account[]>().Result;
            return result;
        }

        public static Contact[] GetAccountSharedContacts(int userid, int accountId)
        {
            string accountContactsApiUri = @"api/account/sharedcontacts";
            string param = string.Format("/?userId={0}&accountId={1}", userid, accountId);
            string accountContactsApiUriString = string.Format("{0}{1}", accountContactsApiUri, param);
            var client = new HttpClient();
            client.BaseAddress = new Uri(intuneServerUri);
            var response = client.GetAsync(accountContactsApiUriString).Result;
            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception("Cannot Read Data");

            var result = response.Content.ReadAsAsync<Contact[]>().Result;
            return result;
        }

        public static Contact[] GetAccountContacts(int userid, int accountId)
        {
            string accountContactsApiUri = @"api/account/account/contacts";
            string param = string.Format("/?userId={0}&accountId={1}", userid, accountId);
            string accountContactsApiUriString = string.Format("{0}{1}", accountContactsApiUri, param);
            var client = new HttpClient();
            client.BaseAddress = new Uri(intuneServerUri);
            var response = client.GetAsync(accountContactsApiUriString).Result;
            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception("Cannot Read Data");

            var result = response.Content.ReadAsAsync<Contact[]>().Result;
            return result;
        }

        public static int[] GetAccountUsers(int accountId, UserAccountRole role)
        {
            string accountContactsApiUri = @"api/account/account/users";
            string param = string.Format("/?accountId={0}&role={1}", accountId, role);
            string accountContactsApiUriString = string.Format("{0}{1}", accountContactsApiUri, param);
            var client = new HttpClient();
            client.BaseAddress = new Uri(intuneServerUri);
            var response = client.GetAsync(accountContactsApiUriString).Result;
            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception("Cannot Read Data");

            var result = response.Content.ReadAsAsync<int[]>().Result;
            return result;
        }

        public static void AddAccountSharing(int accountId, UserAccountShareRole[] accountShares)
        {
            string accountSharingApiUri = @"api/account/sharing";
            string param = string.Format("/?accountId={0}", accountId);
            string accountSharingApiUriString = string.Format("{0}{1}", accountSharingApiUri, param);
            var client = new HttpClient();
            client.BaseAddress = new Uri(intuneServerUri);
            var response = client.PostAsJsonAsync(accountSharingApiUriString, accountShares).Result;
            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception("Cannot share account with contacts");
        }

        public static void AddAccountUser(AccountContactUser acu)
        {
            string accountUserApiUri = @"api/account/adduser";
            var client = new HttpClient();
            client.BaseAddress = new Uri(intuneServerUri);
            var response = client.PostAsJsonAsync(accountUserApiUri, acu).Result;
            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception("Cannot share account with contact");

            //var result = response.Content.ReadAsAsync<JObject>().Result;
        }

        public static void DeleteAccountUser(AccountContactUser acu)
        {
            string accountUserApiUri = @"api/account/deleteuser";
            var client = new HttpClient();
            client.BaseAddress = new Uri(intuneServerUri);
            var response = client.PostAsJsonAsync(accountUserApiUri, acu).Result;
            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception("Cannot unshare account with contact");

            //var result = response.Content.ReadAsAsync<JObject>().Result;
        }

        public static void AddAccountContact(AccountContactUser acu)
        {
            string accountApiUri = @"api/account/addcontact";
            var client = new HttpClient();
            client.BaseAddress = new Uri(intuneServerUri);
            var response = client.PostAsJsonAsync(accountApiUri, acu).Result;
            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception("Cannot Add Account Contact");

            //var result = response.Content.ReadAsAsync<JObject>().Result;
        }

        public static Entry AddAccountEntry(Entry entry)
        {
            string accountEntryApiUri = @"api/account/addentry";
            var client = new HttpClient();
            client.BaseAddress = new Uri(intuneServerUri);
            var response = client.PostAsJsonAsync(accountEntryApiUri, entry).Result;
            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception("Cannot Add Entry");

            var result = response.Content.ReadAsAsync<Entry>().Result;
            return result;
        }

        public static Entry[] GetAccountEntries(int accountId)
        {
            string accountEntriesApiUri = @"api/account/entries";
            string accountEntriesApiUriString = string.Format("{0}{1}{2}", accountEntriesApiUri, "/?accountId=", accountId);
            var client = new HttpClient();
            client.BaseAddress = new Uri(intuneServerUri);
            var response = client.GetAsync(accountEntriesApiUriString).Result;
            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception("Cannot Read Data");

            var result = response.Content.ReadAsAsync<Entry[]>().Result;
            return result;
        }

        public static Comment[] GetContactComments(int byUserId, int toUserId)
        {
            string contactCommentsApiUri = @"api/comment/contact/allcomments";
            string param = string.Format("/?byUserId={0}&toUserId={1}", byUserId, toUserId);
            string contactCommentsApiUriString = string.Format("{0}{1}", contactCommentsApiUri, param);
            var client = new HttpClient();
            client.BaseAddress = new Uri(intuneServerUri);
            var response = client.GetAsync(contactCommentsApiUriString).Result;
            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception("Cannot read data from server");

            var result = response.Content.ReadAsAsync<Comment[]>().Result;
            return result;
        }

        public static Comment AddComment(Comment comment)
        {
            string commentApiUri = @"api/comment/addcomment";
            var client = new HttpClient();
            client.BaseAddress = new Uri(intuneServerUri);
            var response = client.PostAsJsonAsync(commentApiUri, comment).Result;
            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception("Cannot add comment");

            var result = response.Content.ReadAsAsync<Comment>().Result;
            return result;
        }

        public static void MarkAccountCommentAsUnread(int accountId, int userId)
        {
            string accountCommentsApiUri = @"api/comment/account/markasunread";
            string param = string.Format("/?accountId={0}&userId={1}", accountId, userId);
            string accountCommentsApiUriString = string.Format("{0}{1}", accountCommentsApiUri, param);
            var client = new HttpClient();
            client.BaseAddress = new Uri(intuneServerUri);
            var response = client.GetAsync(accountCommentsApiUriString).Result;
            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception("Cannot read data from server");
        }

        public static Comment[] GetAccountComments(int accountId, int userId)
        {
            string accountCommentsApiUri = @"api/comment/account/allcomments";
            string param = string.Format("/?accountId={0}&userId={1}", accountId, userId);
            string accountCommentsApiUriString = string.Format("{0}{1}", accountCommentsApiUri, param);
            var client = new HttpClient();
            client.BaseAddress = new Uri(intuneServerUri);
            var response = client.GetAsync(accountCommentsApiUriString).Result;
            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception("Cannot read data from server");

            var result = response.Content.ReadAsAsync<Comment[]>().Result;
            return result;
        }

        public static Comment[] GetEntryComments(int entryId, int userId)
        {
            string accountEntryCommentsApiUri = @"api/comment/entry/allcomments";
            string param = string.Format("/?entryId={0}&userId={1}", entryId, userId);
            string accountEntryCommentsApiUriString = string.Format("{0}{1}", accountEntryCommentsApiUri, param);
            var client = new HttpClient();
            client.BaseAddress = new Uri(intuneServerUri);
            var response = client.GetAsync(accountEntryCommentsApiUriString).Result;
            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception("Cannot read data from server");

            var result = response.Content.ReadAsAsync<Comment[]>().Result;
            return result;
        }

        public static void SendEmailOtp(string emailAddress)
        {
            string apiName = @"api/email/otp/send";
            string apiParams = string.Format("/?emailAddress={0}", emailAddress);
            string sendEmailOtpApiUri = string.Format("{0}{1}", apiName, apiParams);
            var client = new HttpClient();
            client.BaseAddress = new Uri(intuneServerUri);
            var response = client.GetAsync(sendEmailOtpApiUri).Result;
            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception("Cannot send email OTP");
        }

        public static void VerifyEmailOtp(string emailAddress, string otp)
        {
            string apiName = @"api/email/otp/verify";
            string apiParams = string.Format("/?emailAddress={0}&otp={1}", emailAddress, otp);
            string sendEmailOtpApiUri = string.Format("{0}{1}", apiName, apiParams);
            var client = new HttpClient();
            client.BaseAddress = new Uri(intuneServerUri);
            var response = client.GetAsync(sendEmailOtpApiUri).Result;
            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception("Cannot verify email OTP");
        }

        public static void SendMobileOtp(string isdCode, string mobileNumber)
        {
            var countryIsdCode = isdCode.Substring(0, 1) == "+"
                                 ? isdCode.Substring(1)
                                 : isdCode;

            string apiName = @"api/mobile/otp/send";
            string apiParams = string.Format("/?isdCode={0}&mobileNumber={1}", countryIsdCode, mobileNumber);
            string sendEmailOtpApiUri = string.Format("{0}{1}", apiName, apiParams);
            var client = new HttpClient();
            client.BaseAddress = new Uri(intuneServerUri);
            var response = client.GetAsync(sendEmailOtpApiUri).Result;
            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception("Cannot send email OTP");
        }

        public static void VerifyMobileOtp(string isdCode, string mobileNumber, string otp)
        {
            var countryIsdCode = isdCode.Substring(0, 1) == "+"
                      ? isdCode.Substring(1)
                      : isdCode;

            string apiName = @"api/mobile/otp/verify";
            string apiParams = string.Format("/?isdCode={0}&mobileNumber={1}&otp={2}", countryIsdCode, mobileNumber, otp);
            string sendEmailOtpApiUri = string.Format("{0}{1}", apiName, apiParams);
            var client = new HttpClient();
            client.BaseAddress = new Uri(intuneServerUri);
            var response = client.GetAsync(sendEmailOtpApiUri).Result;
            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception("Cannot verify email OTP");
        }
    }
}
