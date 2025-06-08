// Passos a serem lembrados

git status 
git commit -m ""
git push origin main
git add -u
git add
git clone 

dotnet run / rodar

Principios SOLID aplicados:

S: Cada classe tem uma função bem definida. Por exemplo, a classe Produto só cuida dos dados do produto, e a PedidoService é responsável por criar pedidos.

O: O sistema de descontos foi feito de um jeito que permite criar novas regras de desconto sem precisar mudar o que já existe, usando o padrão Strategy.

L: As classes que representam descontos seguem uma interface comum. Isso permite trocar uma pela outra sem quebrar o funcionamento do sistema.

I: As interfaces foram separadas de acordo com o que cada parte do sistema realmente precisa, sem obrigar nenhuma classe a implementar coisas que não vai usar.

D: Usei interfaces para permitir a troca fácil de ferramentas, como o sistema de log, sem depender diretamente de uma classe específica.
