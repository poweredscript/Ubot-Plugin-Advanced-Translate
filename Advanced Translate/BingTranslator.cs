using System.Collections.Generic;
using MicrosoftTranslatorSdk;
using UBotPlugin;

namespace Advanced_Translate
{
    class BingTranslate : IUBotFunction
    {
        private string _returnValue = "";

        public BingTranslate()
        {
            _parameters.Add(new UBotParameterDefinition("Client Id", UBotType.String));
            _parameters.Add(new UBotParameterDefinition("Client Secret", UBotType.String));
            _parameters.Add(new UBotParameterDefinition("Text", UBotType.String));
            _parameters.Add(new UBotParameterDefinition("Original Language", UBotType.String) {DefaultValue = "en"});
            _parameters.Add(new UBotParameterDefinition("Destination Language", UBotType.String) {DefaultValue = "th"});
        }

        public void Execute(IUBotStudio ubotStudio, Dictionary<string, string> parameters)
        {
            var clientId = parameters["Client Id"].Trim();
            var clientSecret = parameters["Client Secret"].Trim();
            var text = parameters["Text"];
            var originalLanguage = parameters["Original Language"];
            var destinationLanguage = parameters["Destination Language"];

            MicrosoftTranslator microsoftTranslator = new MicrosoftTranslator(clientId, clientSecret);
            _returnValue = microsoftTranslator.Translate(text, originalLanguage, destinationLanguage);
        }

        public string Category
        {
            get { return "Translate"; }
        }

        public string FunctionName
        {
            get { return "$bing translate"; }
        }

        public object ReturnValue
        {
            get { return _returnValue; }
        }

        public bool IsContainer
        {
            get { return false; }
        }

        private readonly List<UBotParameterDefinition> _parameters = new List<UBotParameterDefinition>();

        public IEnumerable<UBotParameterDefinition> ParameterDefinitions
        {
            get { return _parameters; }
        }

        public UBotVersion UBotVersion
        {
            get { return UBotVersion.Standard; }
        }

        public UBotType ReturnValueType
        {
            get { return UBotType.String; }
        }
    }
}
