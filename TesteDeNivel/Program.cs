using System;
using System.Collections.Generic;

namespace GerenciadorDeTarefas
{
    class Tarefa
    {
        //campos
        private int id;
        private string descricao;
        private bool concluido = false;

        //propriedades
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Descricao
        {
            get { return descricao; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    Console.WriteLine("Erro, não foi inserido um texto, tente de novo");
                }
                else
                {
                    descricao = value;
                }
            }
        }
        public bool Concluido
        {
            get { return concluido; }
            set { concluido = value; }
        }

        // metdodo
        public override string ToString()
        {
            string simNao = concluido ? "sim" : "não";
            return $"ID: {id}, Descrição: {descricao}, Concluida?: {simNao}.";
        }
        public Tarefa(int id, string descricao)
        {
            this.Id = id;
            this.Descricao = descricao;
            this.Concluido = false;
        }

    }

    //corpo da lista
  

    class Program
    {
        static List<Tarefa> listaTarefas = new List<Tarefa>();
        

        static void Main(string [] args)
        {


            while (true)
            {
                Console.WriteLine("Bem vindo, digite a opção  que você deseja");
                Console.WriteLine("1 - Para adicionar uma nova tarefa");
                Console.WriteLine("2 - Para exibir as tarefas ");
                Console.WriteLine("3 - Para excluir uma tarefa");
                Console.WriteLine("4 - Para marcar uma tarefa como concluida");
                Console.WriteLine("5 - Para encerrar o programa \n");
                string opcao = Console.ReadLine();

                switch(opcao)
                {
                    case "1":
                        AdicionarTarefa();
                        break;
                    case "2":
                        MostrarTarefas();
                        break;
                    case "3":
                        RemoverTarefa();
                        break;
                    case "4":
                        MarcarComoConcluido();
                        break;
                    case "5":
                        break;
                }
            }
        }



        static void AdicionarTarefa()
        {
            Console.WriteLine("Digite a descrição da tarefa");
            string descricao = Console.ReadLine();
            if (listaTarefas.Count < 1)
            {
                Tarefa objeto = new Tarefa(0, descricao);
                listaTarefas.Add(objeto);
            }
            else
            {
                int id = listaTarefas.Count - 1;
                Tarefa objeto = new Tarefa(id, descricao);
                listaTarefas.Add(objeto);
            }
        }

        static void RemoverTarefa()
        {
            Console.WriteLine("Digite o id da tarefa que você deseja apagar");
            int numero = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Tem certeza de que quer excluir o item: {listaTarefas[numero]}? Sim ou Não");
            string resposta = Console.ReadLine();

            if (resposta == "Sim" || resposta == "sim" || resposta == "s")
            {
                listaTarefas.RemoveAt(numero);
                Console.WriteLine("item excluido com sucesso");
            }
            else
            {
                Console.WriteLine("Cancelado com sucesso ou opção escrita incorretamente");
            }

        }

        static void MarcarComoConcluido()
        {
            Console.WriteLine("Digite o id da tarefa que você deseja marcar como concluido: ");
            int numero = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Tem certeza de que quer marcar como concluido a tarefa: {listaTarefas[numero]}? Sim ou Não");
            string resposta = Console.ReadLine();


            if (resposta == "Sim" || resposta == "sim" || resposta == "s")
            {
                listaTarefas[numero].Concluido = true;
                Console.WriteLine("item marcado como concluido com sucesso");
            }
            else
            {
                Console.WriteLine("Cancelado com sucesso ou opção escrita incorretamente");
            }
        }

         static void MostrarTarefas()
        {
            foreach (Tarefa tarefas1 in listaTarefas)
            {
                Console.WriteLine(tarefas1);
            }
        }


    }


}

