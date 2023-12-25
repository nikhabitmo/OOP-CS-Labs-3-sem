using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Abstractions.Repositories;
using Application.Account;
using ApplicationModels.Transaction;
using Moq;
using Npgsql;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class AccountServiceTests
{
    [Fact]
    public async Task WithdrawWithSufficientBalanceShouldUpdateAccount()
    {
        long accountId = 1;
        long amount = 100;
        var mockRepository = new Mock<IAccountRepository>();
        mockRepository.Setup(repo => repo.GetBalanceAsync(accountId)).ReturnsAsync(200);

        var accountService = new AccountService(mockRepository.Object);

        // Act
        long result = await accountService.WithdrawAsync(accountId, amount).ConfigureAwait(false);

        // Assert
        mockRepository.Verify(repo => repo.WithdrawAsync(accountId, It.IsAny<long>()), Times.Once);
    }

    [Fact]
    public async Task WithdrawWithInsufficientBalanceShouldReturnError()
    {
        // Arrange
        long accountId = 1;
        long amount = 200;
        var mockRepository = new Mock<IAccountRepository>();
        mockRepository.Setup(repo => repo.GetBalanceAsync(accountId)).ThrowsAsync(new NpgsqlException());

        var accountService = new AccountService(mockRepository.Object);

        // Act
        long result = await accountService.WithdrawAsync(accountId, amount).ConfigureAwait(false);

        // Assert
        mockRepository.Verify(repo => repo.WithdrawAsync(It.IsAny<long>(), It.IsAny<long>()), Times.Once);
    }

    [Fact]
    public async Task DepositShouldUpdateAccount()
    {
        // Arrange
        long accountId = 1;
        long amount = 100;
        var mockRepository = new Mock<IAccountRepository>();

        var accountService = new AccountService(mockRepository.Object);

        // Act
        long result = await accountService.DepositAsync(accountId, amount).ConfigureAwait(false);

        // Assert
        mockRepository.Verify(repo => repo.DepositAsync(accountId, It.IsAny<long>()), Times.Once);
    }

    [Fact]
    public async Task GetTransactionHistoryShouldReturnTransactionHistory()
    {
        // Arrange
        long accountId = 1;
        var expectedTransactions = new List<Transaction>
        {
            new Transaction(1, 1, "withdraw", 100, DateTime.Now),
        };
        var mockRepository = new Mock<IAccountRepository>();
        mockRepository.Setup(repo => repo.GetTransactionHistoryAsync(accountId)).ReturnsAsync(expectedTransactions);

        var accountService = new AccountService(mockRepository.Object);

        // Act
        await accountService.WithdrawAsync(1, 100).ConfigureAwait(false);
        IEnumerable<Transaction> result = await accountService.GetTransactionHistoryAsync(accountId).ConfigureAwait(false);

        // Assert
        mockRepository.Verify(repo => repo.GetTransactionHistoryAsync(accountId), Times.Once);
    }
}