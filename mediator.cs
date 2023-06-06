using System;

namespace Mediador{
    public interface IMediator{
        void Notify(object sender, string ev);
    }

    class ConcreteMediator : IMediator{
        private Aluno _aluno;
        private Professor _professor;
        private Monitor _monitor;

        public ConcreteMediator(Aluno Aluno, Professor Professor, Monitor Monitor){
            this._aluno = Aluno;
            this._aluno.SetMediator(this);
            this._professor = Professor;
            this._professor.SetMediator(this);
            this._monitor = Monitor;
            this._monitor.SetMediator(this);
        } 

        public void Notify(object sender, string ev){
            if (ev == "A"){
                Console.WriteLine("Mediator reage em acao_A e executa as seguintes operacoes:");
                this._professor.acao_C();
            }
            if (ev == "D"){
                Console.WriteLine("Mediator reage em acao_D e executa as seguintes operacoes:");
                this._aluno.acao_B();
                this._professor.acao_C();
            }
            if (ev == "F"){
                Console.WriteLine("Mediator reage em acao_F e executa as seguintes operacoes:");
                this._aluno.acao_B();
                this._professor.acao_C();
                this._monitor.acao_E();
            }
        }
    }

    class ClasseBase{
        protected IMediator _mediator;

        public ClasseBase(IMediator mediator = null){
            this._mediator = mediator;
        }

        public void SetMediator(IMediator mediator){
            this._mediator = mediator;
        }
    }

    class Aluno : ClasseBase{
        public void acao_A(){
            Console.WriteLine("Aluno faz acao_A.");

            this._mediator.Notify(this, "A");
        }

        public void acao_B(){
            Console.WriteLine("Aluno faz acao_B.");

            this._mediator.Notify(this, "B");
        }
    }

    class Professor : ClasseBase{
        public void acao_C(){
            Console.WriteLine("Professor faz acao_C.");

            this._mediator.Notify(this, "C");
        }

        public void acao_D(){
            Console.WriteLine("Professor faz acao_D.");

            this._mediator.Notify(this, "D");
        }
    }

    class Monitor : ClasseBase{
        public void acao_E(){
            Console.WriteLine("Monitor faz acao_E.");

            this._mediator.Notify(this, "E");
        }

        public void acao_F(){
            Console.WriteLine("Monitor faz acao_F.");

            this._mediator.Notify(this, "F");
        }
    }
    
    class Program{
        static void Main(string[] args){
            Aluno Aluno = new Aluno();
            Professor Professor = new Professor();
            Monitor Monitor = new Monitor();
            
            new ConcreteMediator(Aluno, Professor, Monitor);

            Console.WriteLine("Cliente (Aluno) ativa acao_A.\n");
            Aluno.acao_A();

            Console.WriteLine();

            Console.WriteLine("Cliente (Professor) ativa acao_D.\n");
            Professor.acao_D();

            Console.WriteLine();

            Console.WriteLine("Cliente (Monitor) ativa acao_F.\n");
            Monitor.acao_F();
        }
    }
}