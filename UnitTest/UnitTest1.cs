using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TaskBenner;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
       
        [TestMethod]
        public void TryExerciseDirectConnection()
        {
            Network test = new Network(8);

            test.Connect(1, 2);
            test.Connect(6, 2);
            test.Connect(2, 4);
            test.Connect(5, 8);

            Assert.IsTrue(test.Query(1, 2));
        }

        [TestMethod]
        public void TryExerciseIndirectConnection()
        {
            Network test = new Network(8);

            test.Connect(1, 2);
            test.Connect(6, 2);
            test.Connect(2, 4);
            test.Connect(5, 8);

            Assert.IsTrue(test.Query(6, 4));
        }

        [TestMethod]
        public void TryExerciseUnconnected()
        {
            Network test = new Network(8);

            test.Connect(1, 2);
            test.Connect(6, 2);
            test.Connect(2, 4);
            test.Connect(5, 8);

            Assert.IsFalse(test.Query(8, 2));
        }


        [TestMethod]
        public void TryExerciseConnectedFarAway()
        {
            Network test = new Network(8);

            test.Connect(1, 2);
            test.Connect(6, 2);
            test.Connect(2, 3);
            test.Connect(3, 4);
            test.Connect(5, 8);

            Assert.IsTrue(test.Query(6, 4));
        }


        [TestMethod]
        public void TryExerciseNumberUniquesExceed()
        {
            Network test = new Network(8);
            try
            {
                test.Connect(1, 2);
                test.Connect(3, 4);
                test.Connect(5, 6);
                test.Connect(7, 8);
                test.Connect(9, 8);
            }
            catch (Exception e)
            {
                Assert.AreEqual(e.Message, "Unique elements exceeded");
            }
            
        }

        [TestMethod]
        public void TryExerciseNumberConnectionsExceed()
        {
            Network test = new Network(8);
            try
            {
                test.Connect(1, 2);
                test.Connect(1, 2);
                test.Connect(5, 6);
                test.Connect(7, 8);
                test.Connect(2, 8);
            }
            catch (Exception e)
            {
                Assert.AreEqual(e.Message, "Connections already inserted");
            }

        }


        [TestMethod]
        public void TryExerciseNumberNotInConnections()
        {
            Network test = new Network(8);
            try
            {
                test.Connect(1, 2);
                test.Connect(1, 3);
                test.Connect(5, 6);

                test.Query(8, 7);
            }
            catch (Exception e)
            {
                Assert.AreEqual(e.Message, "Informed numbers are not in Connections List");
            }

        }

        //Teste para verificar números unicos inseridos nas conexões (Inserir 9 números diferentes, deve dar erro ao inserir o NONO)
        //Teste para verificar se numeros estão conectados
    }
}
