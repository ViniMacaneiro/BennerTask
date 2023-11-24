﻿using System;
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

            List<List<List<int>>> list = new List<List<List<int>>>();
            list.Capacity = validateNumbers.Elements.Count;
            
            if (VerifyValidateNumbers(validateNumbers.Elements))
            {
                for (var listNumber = 0; listNumber < list.Count; listNumber++)
                {
                    foreach (var number in validateNumbers.Elements)
                    {
                        for (int i = 0; i < Connections.Count; i++)
                        {
                            for (int j = 0; j < Connections[i].Count; j++)
                            {
                                if (Connections[i][j] == number)
                                {
                                    list[listNumber].Add(Connections[i]);
                                }
                            }
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
        public bool VerifyConnection(List<List<int>> list, int number)
        {
            for (var l = 0; l < list.Count; l++)
            {
                for (int k = 0; k < list[l].Count; k++)
                {
                    if (list[l][k] == number)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
