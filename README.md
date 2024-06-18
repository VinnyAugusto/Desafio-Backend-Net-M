------------------
Desafio Backend
------------------

A versão do .NET utilizada foi a 8.0

O banco de dados utilizado foi o postgres, e o ORM foi o EntityFramework Core.

Para testes:

Tendo o postgres instalado, crie o database chamado DesafioM.
E configure a connectionstring (LocalPostgres) no arquivo: ~\Desafio\Desafio.Api\appsettings.json

Caso queria utilizar outro nome de database, basta alterar na connectionstring.

Apos isso, entre no modo commandLine do visual studio (Tools > Command Line > Developer command prompt).
E Navegue ate a pasta \Desafio\Desafio.Infrastructure (ex: cd Desafio.Infrastructure)

Para que o EntityFramework crie as tabelas no banco de dados, utilize o comando:

dotnet ef database update -s ../Desafio.Api/Desafio.Api.csproj

Caso tenha algum erro na execucao do comando, garanta que o EntityFramewor está instalado com o comando:

dotnet tool install --global dotnet-ef

O projeto principal é uma API, então ao startar a aplicação, será aberto o swagger com as APIs para testes.


Obs:
Rent Plans:
1: 7 dias 
2: 15 dias
3: 30 dias
4: 45 dias
5: 50 dias




