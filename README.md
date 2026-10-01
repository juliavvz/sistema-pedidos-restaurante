Markdown


# 🍳 Sistema de Gestão de Cozinha Industrial

Projeto em **C#** desenvolvido para a disciplina de **Estrutura de Dados 2 (CBTEDD2)**. O sistema gerencia o fluxo diário de até 50 pedidos em uma cozinha industrial, permitindo adicionar/remover itens, calcular o valor total de cada pedido e consultar a receita geral do dia.

---

## 🎯 Funcionalidades

- **0. Sair:** Encerra a aplicação.
- **1. Criar novo pedido:** Registra um novo pedido atribuindo ID automático sequencial e vinculando o nome do cliente.
- **2. Adicionar item ao pedido:** Insere um item (ID, descrição e preço) no pedido informado (limite de 10 itens por pedido).
- **3. Remover item do pedido:** Remove um item do pedido ajustando a estrutura de vetor.
- **4. Consultar pedido:** Exibe detalhes, itens e o valor total calculado de um pedido específico.
- **5. Cancelar pedido:** Remove o pedido do sistema e reorganiza a lista de pedidos.
- **6. Listar todos os pedidos:** Exibe o histórico de pedidos do dia com ID, totais individuais e o faturamento total acumulado.

---

## 📁 Estrutura do Repositório

```text
sistema-pedidos-restaurante/
├── src/
│   └── main.cs       # Código-fonte principal da aplicação
└── README.md         # Documentação do projeto
📐 Diagrama de Classes
Plaintext


+---------------------+
| Item                |
+---------------------+
| - id: int           |
| - descricao: string |
| - preco: double     |
+---------------------+

+----------------------------------+
| Pedido                           |
+----------------------------------+
| - id: int                        |
| - cliente: string                |
| - itens: Item[10]                |
+----------------------------------+
| + adicionarItem(Item item): bool |
| + removerItem(Item item): bool   |
| + dadosDoPedido(): string        |
| + calcularTotal(): double        |
+----------------------------------+

+---------------------------------------+
| Restaurante                           |
+---------------------------------------+
| - proxPedido: int                     |
| - pedidos: Pedido[50]                 |
+---------------------------------------+
| + novoPedido(Pedido pedido): bool     |
| + buscarPedido(Pedido pedido): Pedido |
| + cancelarPedido(Pedido pedido): bool |
+---------------------------------------+
🛠️ Tecnologias e Conceitos Utilizados
Linguagem: C# (.NET Console Application)

Paradigma: Orientação a Objetos (Classes, Atributos, Métodos, Encapsulamento)

Estruturas de Dados: Vetores estáticos (Arrays) com manipulação de índices e deslocamento para remoções.

🚀 Como Executar
Certifique-se de ter o .NET SDK instalado em sua máquina.

## Clone o repositório:
´´´´
git clone [https://github.com/juliavvz/sistema-pedidos-restaurante.git](https://github.com/juliavvz/sistema-pedidos-restaurante.git)

´´´´
## Navegue até a pasta do código-fonte:

´´´´
cd sistema-pedidos-restaurante/src
´´´´
Execute o programa:

Bash


dotnet run
