using CheckMed.Enums;

namespace CheckMed.MedClient
{
    public class ClientCommand
    {
        private string _body = "";

        public ClientCommand AddMenuCode(Commands command)
        {
            _addBodyKeys("COMMAND", command.GetHashCode().ToString());
            return this;
        }

        public ClientCommand AddSpecCode(string specKey)
        {
            _addBodyKeys("CODESPEC", specKey);
            return this;
        }

        public ClientCommand AddDoctorCode(string docCode)
        {
            _addBodyKeys("CODEMED", docCode);
            return this;
        }

        public ClientCommand AddAnyTimeCommand()
        {
            _addBodyKeys("DATE", "31/12/9999");
            return this;
        }

        public ClientCommand AddAnyDoctorCommand()
        {
            _addBodyKeys("CODEMED", "Любой доктор");
            return this;
        }

        public string ToForm()
        {
            return _body;
        }
        
        private void _addBodyKeys(string key, string value)
        {
            if (_body.Length != 0) _body += "&";
            _body += key + "=" + value;
        }
    }
}