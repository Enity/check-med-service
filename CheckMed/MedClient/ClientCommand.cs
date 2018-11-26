using CheckMed.Enums;

namespace CheckMed.MedClient
{
    internal class ClientCommand
    {
        public string Body { get; private set; } = "";

        public ClientCommand AddMenuCommand(Commands command)
        {
            _addBodyKeys("COMMAND", command.GetHashCode().ToString());
            return this;
        }

        public ClientCommand AddSpecCommand(string specKey)
        {
            _addBodyKeys("CODESPEC", specKey);
            return this;
        }
        
        private void _addBodyKeys(string key, string value)
        {
            if (Body.Length != 0) Body += "&";
            Body += key + "=" + value;
        }
    }
}