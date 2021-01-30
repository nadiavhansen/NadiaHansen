# API HTTP “Escola” - Correção de Provas da Escolares

## Descrição

Esta API HTTP foi desenvolvida com o intuito de construir uma alternativa para correção de provas escolares de forma automatizada, permitindo os seguintes recursos;

``` bash
- Cadastrar o gabarito de cada prova;
- Cadastrar as respostas de cada aluno para cada prova;
- Verificar a nota final de cada aluno;
- Listar os alunos aprovados;
```

## Construção

A seguir é apresentada uma imagem da estrutura de solução criada para sustentar as funcionalidades descritas acima;

![EstruturaEscola](https://i.ibb.co/qm9BSkc/Estrutura-Escola.png)

As camadas apresentadas na imagem possuem as seguintes funções;

``` bash
Controllers – Controladores responsáveis por obter as informações de entrada, invocar os tratamentos necessários e retornar os resultados.

ViewModel – Configurações de exibição dos resultados para melhor interpretação do usuário das informações geradas.

Entidades – Definição das variáveis utilizadas na solução, como um gabarito de questões e as respostas de cada respectivo aluno.

Infra – Contexto de sustentação da solução, envolvendo banco de dados simples utilizado para manter as informações de comparação, assim como as conexões necessárias entre os dados fornecidos e gerados.

Service – Construção dos serviços e funcionalidades que o projeto apresenta, envolvendo os cálculos de peso das notas e médias finais, por exemplo.

Test – Testes de execução realizados para simular a rotina de um professor ao corrigir as provas dos alunos e obter as médias desejadas, tal como a lista de alunos aprovados.
```

## Instalação

Para a construção e testes de usabilidade, foi utilizado o software gratuito da empresa Microsoft chamado Visual Studio 2019, disponível para download neste [link](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=Community&rel=16).

Instalando este software com os pacotes opcionais básicos de desenvolvimento e execução, é possível executar o projeto em questão e testar suas funções.

## Utilização

Para utilizar este desenvolvimento, basta seguir os passos de instalação descritos acima e executar o projeto na ferramenta escolhida. No caso, Visual Studio.

A API não apresenta interface, então os dados de entrada são submetidos via arquivo JSON, conforme os exemplos abaixo;

- Gabarito de respostas
```C#
{
  "CodigoGabarito": 1,
  "CodigoProva": 1,
  "Questoes": [{
    "CodigoQuestao": 1,
    "Resposta": "B"
  },{
    "CodigoQuestao": 2,
    "Resposta": "B"
  },{
    "CodigoQuestao": 3,
    "Resposta": "B"
  }
  ]
}
```

- Cartão de respostas do aluno
```C#
{
  "CodigoCartaoResposta": 1,
  "Matricula": 1,
  "Nome": "Nadia",
  "CodigoProva": 1,
  "Questoes": [{
    "CodigoAluno": 1,
    "CodigoQuestao": 1,
    "Resposta": "B"
  },{
    "CodigoAluno": 1,
    "CodigoQuestao": 2,
    "Resposta": "B"
  },{
    "CodigoAluno": 1,
    "CodigoQuestao": 3,
    "Resposta": "B"
  }
  ]
}
```

Feita a entrada dos dados necessários, a abertura do host informado pela aplicação fornece o local origem para informar as funções desejadas, como por exemplo:

- Retornar os alunos que estão aprovados
```bash
http://localhost:5000/escola/buscarAlunosAprovados
```

Assim, serão informados os dados gerados pela aplicação.

## Suporte

No momento o projeto não conta com suporte contínuo da solução.

## Roadmap

O projeto foi desenvolvido em um curto período, então pode conter bugs ou comportamento não esperado. Porém não deve receber atualizações tão cedo.

## Contribuições

A autora agradece as opiniões e sugestões de melhoria que possam direcionar a ela após utilizar a solução, ficando à disposição para contribuições futuras. 

## Autoria

Nádia Vanzuita Hansen, engenheira química aspirante à desenvolvedora de soluções tecnológicas.

## Licença de utilização

Projeto open source, sem utilização de licenças ou restrições de uso.

## Status do projeto

Versão inicial 1.0 concluída e entregue em 29/01/2021.
