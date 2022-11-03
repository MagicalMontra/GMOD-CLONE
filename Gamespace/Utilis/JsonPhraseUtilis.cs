public class JsonPhraseUtilis
{
    public string Convert(string jsonWrapper)
    {
        bool detectedQuote = false;
        string json = "";

        for (int i = 0; i < jsonWrapper.Length; i++)
        {
            if (detectedQuote && jsonWrapper[i] == '"')
            {
                detectedQuote = false;
                continue;
            }

            json += jsonWrapper[i];
            
            if (jsonWrapper[i] == '"')
                detectedQuote = true;
        }

        return json;
    }
}