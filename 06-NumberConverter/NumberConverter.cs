
namespace NumberConverters 
{
    /// <summary>
    /// Zur Verfügung gestellt von Peter Gisler, GIBZ
    /// </summary>
    public class NumberConverter 
    {

        IStringConverter _stringConverter;

        public NumberConverter(IStringConverter stringConverter = null)
        { 
            _stringConverter = stringConverter;
        }

        public int RoundUp(float value) 
        {
            return 0;
        }
        
        public int RoundDown(float value) 
        {
            return 0;
        }


        public int RoundToPowerOfTen(float value, int precisionExponent = 1) 
        {
            return 0;
        }

        public int RoundToPowerOfTen(string numericString, int precisionExponent = 1) 
        {
            return 0;
        }

    }
}
