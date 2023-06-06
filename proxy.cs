using System;

namespace Proxy{
    public interface IClassePadrao{
        void Requisicao();
    }
    
    class BDClasse : IClassePadrao{
        public void Requisicao(){
            Console.WriteLine("BDClasse: Manuseando Requisicao...");
        }
    }
    
    class Proxy : IClassePadrao{
        private BDClasse _BDClasse;
        
        public Proxy(BDClasse BDClasse){
            this._BDClasse = BDClasse;
        }
        
        public void Requisicao(){
            if (this.ChecarAcesso()){
                this._BDClasse.Requisicao();

                this.LogarAcesso();
            }
        }
        
        public bool ChecarAcesso(){
            // Checks reais vão aqui.
            Console.WriteLine("Proxy: Checando acesso antes de enviar Requisicao.");

            return true;
        }
        
        public void LogarAcesso(){
            Console.WriteLine("Proxy: Salvando (logando) hora de Requisicao.");
        }
    }
    
    public class Cliente{
        public void Agendar(IClassePadrao subject){
            // ...
            
            subject.Requisicao();
            
            // ...
        }
    }
    
    class Program{
        static void Main(string[] args){
            Cliente Cliente = new Cliente();
            
            Console.WriteLine("Cliente: cliente acessando BD diretamente:");
            BDClasse BDClasse = new BDClasse();
            Cliente.Agendar(BDClasse);

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Cliente: cliente acessando BD atraves do proxy:");
            Proxy proxy = new Proxy(BDClasse);
            Cliente.Agendar(proxy);
        }
    }
}