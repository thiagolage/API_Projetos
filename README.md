# APIProjetos
Este projeto foi criado em caráter de teste para a empresa EclipseWorks.

## 🚀 Começando
Este projeto se trata de uma API que permite aos usuários organizar e monitorar suas tarefas diárias, bem como colaborar com colegas de equipe.

## 🛠️ Construído com
* [Visual Studio](https://visualstudio.microsoft.com/pt-br/vs/community/) - IDE de Desenvolvimento
* [SQL Server](https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16) - Sistema Gerenciador de Banco de Dados

## 📋 Antes de executar o Projeto na IDE
* Foi utilizada a abordagem Code First e Migration para mapear as alterações de estrutura no Banco. Portanto antes da primeira execução, no terminal da IDE, digite os comandos (nessa ordem:
  - "Add-Migration BancoInicial"
  - "Update-Database"
* Desta forma o Entity Framework irá criar toda a estrutura de Banco de Dados necessária no servidor local e a aplicação poderá ser executada sem erros de conexão com a base de dados.

## 📌 Versionamento
Este projeto utiliza o [GitHub](https://github.com/) para controle de versão.

## ✒️ Autor
* **Thiago Augusto** - [LinkedIn](https://www.linkedin.com/in/thiago-augusto-aa160468/)

------------

# 📄 Sessões Dedicadas
## ⚙️ Perguntas para o PO do Projeto
* Podemos ter mais de dois perfis de Usuário no futuro? Se sim, haverão regras específicas para cada um deles? Quais regras?
* Poderemos ter dependências entre Projetos (um só pode iniciar após outro ser concluído)?
* Pode haver dependência entre Tarefas de Projetos distintos?
* Haverão mais tipos relatórios?

## 🔧 Pontos de melhoria na visão do **[Autor](#%EF%B8%8F-autor)**
* Implementação de mais testes unitários.
* Autenticação dos usuários.
* Criação de triggers diretamente no Banco de Dados para gravação dos logs.

## 🛠️ Docker
* É a parte que ainda não domino tecnicamente, apesar de entender o conceito de conteinerização para poder executar a aplicação em diversos ambientes diferentes.
