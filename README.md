# BackgroundServiceExamples

Repositório com implementações básicas de **Background Services** no .NET, utilizando C#.  
Ideal para quem deseja entender como funcionam os serviços executados em segundo plano com `IHostedService` e `BackgroundService`.

## 🔧 Projetos incluídos

Este repositório contém 4 projetos separados, cada um demonstrando um tipo ou abordagem de execução em background no .NET:

| Projeto                    | Descrição                                                                 |
|----------------------------|---------------------------------------------------------------------------|
| `GenericHostExample`       | Exemplo básico de uso do `GenericHost` com serviços de background.        |
| `HostedServiceExample`     | Demonstra a implementação manual de um `IHostedService`.                  |
| `ConsumerQueueExample`     | Implementa uma fila (queue) com consumidor processando dados em paralelo. |
| `PeriodicProcessingExample`| Executa tarefas de forma periódica com `Timer` ou `Delay`.                |


## ▶️ Como executar

Clone o repositório:

```bash
git clone https://github.com/gustasantos/BackgroundServiceExamples.git
cd BackgroundServiceExamples
```

Execute qualquer um dos projetos com o seguinte comando:
```bash
dotnet run --project NomeDoProjeto
```
Exemplo:
```bash
dotnet run --project ConsumerQueueExample
