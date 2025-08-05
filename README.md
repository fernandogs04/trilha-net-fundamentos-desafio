# DIO - Trilha .NET - Fundamentos - Sistema de Estacionamento
www.dio.me

## Contexto
Você foi contratado para construir um sistema para um estacionamento, que será usado para gerenciar os veículos estacionados e realizar suas operações, como por exemplo adicionar um veículo, remover um veículo (e exibir o valor cobrado durante o período) e listar os veículos.

## 📋 Sobre o Projeto
Este projeto implementa o desafio de fundamentos da trilha .NET da DIO, indo além dos requisitos básicos com melhorias significativas na robustez e qualidade do código. 

O sistema implementa todas as funcionalidades solicitadas no desafio original, mas adiciona validações, tratamento de erros e uma suíte de testes unitários.

## 🚀 Melhorias Implementadas
*Funcionalidades adicionais implementadas além dos requisitos do desafio:*
- **Atualização para .NET 9.0**: Versão mais recente do .NET
- **Nullable Reference Types**: Habilitado para maior segurança de tipos
- **Arquitetura limpa**: Separação clara entre Models e Program
- **Validações**: Validação completa com exceções tipadas
- **Testes**: Vários cenários de teste com xUnit

## 🏗️ Arquitetura

### Estrutura do Projeto
```
DesafioFundamentos/
├── Models/
│   └── Estacionamento.cs           # Classe principal do sistema
├── Program.cs                      # Interface de usuário e menu
└── DesafioFundamentos.csproj       # Configurações do projeto

DesafioFundamentos.Tests/
├── EstacionamentoTest.cs           # Testes unitários completos
└── DesafioFundamentos.Tests.csproj # Configurações do projeto de testes
```
---
*Projeto desenvolvido como parte da Trilha .NET - Fundamentos da Digital Innovation One (DIO)*
