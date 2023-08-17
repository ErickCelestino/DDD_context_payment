# DDD context payment

## Comands

- Para criar uma solution
```bash
    dotnet new sln
```
- Para criar uma class lib utilizar o comando
```bash
    dotnet new classlib
```
- Para criar um setup de teste podemos utilizar 
```bash
    dotnet new mstest
```
- Para adicionar o projeto a solução basta utilizar o comando
```bash
    dotnet sln add .\DDD_context_payment.Domain.csproj
```

- Para restaurar os projetos basta utilizar
```bash
    dotnet restore
```

- Para criar um build da aplicação basta utilizar
```bash
    dotnet build
```

- Para criar referencias para outros projetos basta digitar
```bash
   dotnet add reference ..\DDD_context_payment.Shared\DDD_context_payment.Shared.csproj
```
