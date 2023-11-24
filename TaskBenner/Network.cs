using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskBenner
{
    public class Network
    {
        public List<List<int>> Connections { get; set; } = new List<List<int>>();
        public Network(int listLength)
        {
            Connections.Capacity = listLength;
        }
        public void Connect(int number1, int number2)
        {
            var insertElements = new Connection(number1, number2);
            Connections.Add(insertElements.Elements);
        }
        public bool Query(int validateNumber1, int validateNumber2)
        {
            var validateNumbers = new Connection(validateNumber1, validateNumber2);

            if (VerifyValidateNumbers(validateNumbers.Elements))
            {
                foreach (var element in Connections)
                {
                    for (var i = 0; i < Connections.Count; i++)
                    {
                    for (var j = 0; j < validateNumbers.Elements.Count; j++)
                    {

                    }

                    }
                }
            }
            return false;
        }
        //Verifica se os numeros em valiação (validateNumber 1 e 2) existe na lista de conexões (Connections)
        public bool VerifyValidateNumbers(List<int> elements)
        {
            for (var i = 0; i < Connections.Count; i++)
            {
                for (var j = 0; j < Connections[i].Count; j++)
                {
                    for (var k = 0; k < elements.Count; k++)
                    {
                        if (Connections[i][j] == elements[k])
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
