# testepraticohavan

Questão 1 - Conceitos de Orientação a Objetos Runtime do .Net

* Qual é a diferença fundamental entre Classes (Value Types vs Reference Types) em 
C# e como isso afeta o uso de memória (Stack vs Heap)? 

Value Types vs Reference Types
A principal diferença que eu vejo entre Value Types e Reference Types é a forma como o valor é armazenado e passado entre as variáveis.

Nos Value Types, "int, bool, double", a variável guarda o próprio valor. Se eu atribuir uma variável a outra, o valor é copiado, ai se eu alterar uma delas depois, a outra vai continuar com o valor anterior.

Nos Reference Types, a variável trabalha com uma referência para o objeto, "nas classes e nos arrays", conforme a atribuição da variável ambas podem apontar pro mesmo objeto em algum momento.

Em C# costumamos associar Stack a variáveis locais e Heap aos objetos criados durante o execute, mas não é como se sempre o Value Type vai ficar na Stack e o Reference Type vai ficar na Heap, tudo depende de como é o contexto acredito que entendendo como cada um funciona tipo Value Types são diretos aos valores e o Reference Type atua com referências para os objetos.

* Explique  a  diferença  entre  usar  ‘Interface’  e  ‘Classe  Abstrata’.  Dê  um  exemplo 
prático de quando escolheria uma em detrimento da outra.

Interface vs Classe Abstrata


A Interface serve para definir o que uma classe precisa disponibilizar, mas cada classe pode implementar esse comportamento de diversas maneiras, exemplo: em um sistema de envio de notificações, poderiamos ter a interface de Notification com um método de enviar(), depois disso poderia ter classes para enviar de outras formas como e-mail, sms, whatsapp. Ambas tem nelas o que precisam mas cada uma tem um tipo de implementação diferente.

Uma classe abstrata eu vejo de uma forma mais simples, eu usaria quando preciso compartilhar propriedades ou comportamentos entre as classes, exemplo: seguindo o sistema de notificação eu posso ter uma classe abstrata que vai ter diversas propriedades nela como o Nome, assim se eu consigo aproveitar a estrutura dela assim outras classes poderiam herdar as informações e também implementar outros comportamentos.

Em resumo, usaria Interface quando preciso ter diferentes implementações e usaria classe abstrata quando precisasse herdar ou compartilhar parte do código entre as classes.

* O  que  é  e  para  que  serve  o  operador  ‘async/await’?  O  que  acontece  na  prática 
quando uma thread do .NET executa uma operação assíncrona? 

async/await

O async significa que o método usa operações assíncronas, já o await é para quando precisa esperar o resultado de uma operação, na prática, quando o código executa e chega em um await que a operação nao terminou, a thread nao fica parada esperando, ela vai executar alguma outra coisa da fila ai quando a operação terminar ela volta para o código e continua do ponto que tinha parado, usar async/await é muito útil pra deixar as aplicações responsivas e lidar com diversas operações de entrada e saída que acontecem ao mesmo tempo.