# system-design-initial
Repositório contendo o modelo inicial para apresentação do tema System Design


# Caso de uso

Estamos lançando em nossa plataforma um novo produto para nossos novos clientes. Estaremos disponibilizando cartões de crédito com limites pré-aprovados para que eles possam fazer suas compras. Quando esses novos cliente se cadastrarem no nosso sistema, o cartão deve ser disponibilizado com um limite baseado no risco e na renda desse cliente.


## Regras para o risco

* Cliente é funcionário público - Score 10
* Cliente é autonomo - Score 10
* Cliente Politicamente Exposto - Score -10
* Outros - Score 50

## Regras para renda

* Clientes com renda abaixo de R$ 1.000,00 - Score 5
* Clientes com renda entre R$ 1.000,00 e R$ 3.000,00 - Score 10
* Clientes com renda entre R$ 3.000,00 e R$ 8.000,00 - Score 20
* Clientes com renda entre R$ 8.000,00 e R$ 20.000,00 - Score 30
* Clientes com renda entre R$ 20.000,00 e R$ 50.000,00 - Score 20
* Clientes com renda acima de R$ 50.000,00 - Score 5

## Liberação de crédito

* Score < 20 - 20% da renda informada
* Score entre 20 e 40 - 30% da renda informada
* Score entre 40 e 60 - 40% da renda informada
* Score entre 60 e 100 - 50% da renda informada