using AutoFixture;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SocialAppBackend.UnitTests
{
    public class BankServiceUnitTests
    {
        Fixture _fixture;
        IBankService _bankService;
        Mock<IBankDal> _bankDalMock;
        public BankServiceUnitTests()
        {
            _fixture = new Fixture();
            _bankDalMock = new Mock<IBankDal>();
            _bankService = new BankManager(_bankDalMock.Object);
        }
        
        [Fact]
        public async Task BankService_GetAll_Should_Return_SuccessDataResult()
        {
            var data = _fixture.Create<List<Bank>>();
            _bankDalMock.Setup(x => x.GetAllAsync(null)).Returns(Task.FromResult(data));
            var result =  await _bankService.GetAllAsync();
            result.Should().BeOfType<SuccessDataResult<List<Bank>>>();
        }

        [Fact]
        public void BankService_GetCoinsByUserId_Should_Return_SuccessDataResult()
        {
            var data = _fixture.Create<UserCoinBankDto>();
            var id = _fixture.Create<int>();
            _bankDalMock.Setup(x => x.GetCoinsByUserId(id)).Returns(data);
            var result = _bankService.GetCoinsByUserId(id);
            result.Should().BeOfType<SuccessDataResult<UserCoinBankDto>>();
        }
        [Fact]
        public void BankService_GetCooperCoinByUserId_Should_Return_SuccessDataResult()
        {
            var data = _fixture.Create<UserSpecificCoinDto>();
            var id = _fixture.Create<int>();
            _bankDalMock.Setup(x => x.GetCooperCoinByUserId(id)).Returns(data);
            var result = _bankService.GetCooperCoinByUserId(id);
            result.Should().BeOfType<SuccessDataResult<UserSpecificCoinDto>>();
        }
        [Fact]
        public void BankService_GetGoldCoinByUserId_Should_Return_SuccessDataResult()
        {
            var data = _fixture.Create<UserSpecificCoinDto>();
            var id = _fixture.Create<int>();
            _bankDalMock.Setup(x => x.GetGoldCoinByUserId(id)).Returns(data);
            var result = _bankService.GetGoldCoinByUserId(id);
            result.Should().BeOfType<SuccessDataResult<UserSpecificCoinDto>>();
        }
        [Fact]
        public void BankService_GetSilverCoinByUserId_Should_Return_SuccessDataResult()
        {
            var data = _fixture.Create<UserSpecificCoinDto>();
            var id = _fixture.Create<int>();
            _bankDalMock.Setup(x => x.GetSilverCoinByUserId(id)).Returns(data);
            var result = _bankService.GetSilverCoinByUserId(id);
            result.Should().BeOfType<SuccessDataResult<UserSpecificCoinDto>>();
        }
        [Fact]
        public void BankService_GetCopperCoinWallets_Should_Return_SuccessDataResult()
        {
            var data = _fixture.Create<List<UserSpecificCoinDto>>();
            _bankDalMock.Setup(x => x.GetCopperCoinWallets()).Returns(data);
            var result =  _bankService.GetSilverCoinWallets();
            result.Should().BeOfType<SuccessDataResult<List<UserSpecificCoinDto>>>();
        }
        [Fact]
        public void BankService_GetGoldCoinWallets_Should_Return_SuccessDataResult()
        {
            var data = _fixture.Create<List<UserSpecificCoinDto>>();
            _bankDalMock.Setup(x => x.GetGoldCoinWallets()).Returns(data);
            var result =  _bankService.GetSilverCoinWallets();
            result.Should().BeOfType<SuccessDataResult<List<UserSpecificCoinDto>>>();
        }
        [Fact]
        public  void BankService_GetSilverCoinWallets_Should_Return_SuccessDataResult()
        {
            var data = _fixture.Create<List<UserSpecificCoinDto>>();
            _bankDalMock.Setup(x => x.GetSilverCoinWallets()).Returns(data);
            var result =  _bankService.GetSilverCoinWallets();
            result.Should().BeOfType<SuccessDataResult<List<UserSpecificCoinDto>>>();
        }



    }
}
