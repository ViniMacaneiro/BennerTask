using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskBenner
{
    public class Network
    {
        public List<Connection> Connections { get; set; } = new List<Connection>();
        private List<int> uniqueNumber = new List<int>();

        private int uniqueElementsLimit = -1;

        public Network(int listLength)
        {
            uniqueElementsLimit = listLength;
        }

        public void Connect(int number1, int number2)
        {
            ConnectValidation(number1, number2);

            var insertElements = new Connection(number1, number2);
            Connections.Add(insertElements);
        }

        private void ConnectValidation(int number1, int number2)
        {
            if (!uniqueNumber.Contains(number1))
                uniqueNumber.Add(number1);
            if (!uniqueNumber.Contains(number2))
                uniqueNumber.Add(number2);
            if (uniqueNumber.Count > uniqueElementsLimit)
                throw new Exception("Unique elements exceeded");
            if (Connections.Any(c => c.Elements.Contains(number1) && c.Elements.Contains(number2)))
                throw new Exception("Connections already inserted");
        }

        public bool Query(int validateNumber1, int validateNumber2)
        {
            var connectionTested = new Connection(validateNumber1, validateNumber2);
            var OccurrenceValidateNumber1 = GetConnectionByNumber(validateNumber1, Connections);
            foreach (var validConnection in OccurrenceValidateNumber1)
            {
                if (validConnection.Elements.Contains(validateNumber2))
                    return true;
                else
                {
                    var otherElementConnection = validConnection.Elements.FirstOrDefault(n => n != validateNumber1);
                    bool found = VerifyConnection(otherElementConnection, validateNumber2);
                    if (found)
                        return true;
                }
            }
            return false;
        }

        public bool VerifyConnection(int validateElement, int validateNumber2)
        {
            List<Connection> tryVerificateConnection = GetConnectionByNumber(validateElement, Connections);
            foreach (var connection in tryVerificateConnection)
            {
                if (connection.Elements.Contains(validateNumber2))
                    return true;
            }
            
            return false;
        }


        public bool verifyIfNumbersAreInClassConnection(Connection testConnection)
        {
            foreach (var verifyNumbers in Connections)
            {
                if (verifyNumbers.Elements == testConnection.Elements)
                    return true;
            }
            return false;
        }


        public List<Connection> GetConnectionByNumber(int Number, List<Connection> connections)
        {
            List<Connection> result = new List<Connection>();
            foreach (var connection in connections)
            {
                if (connection.Elements.Contains(Number))
                    result.Add(connection);
            }
            return result;
        }


    }
}
