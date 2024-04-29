using App.Core.Interfaces;
using App.DataAccess.Interfaces;
using App.DTOs;
using AutoMapper;

namespace App.Core.Business;
public class OperationBusiness : IOperationBusiness
{
    private readonly IOperationDao _opDao;
    private readonly IMapper _mapper;

    public OperationBusiness(IOperationDao opDao, IMapper mapper)
    {
        _opDao = opDao;
        _mapper = mapper;
    }

    public async Task<List<OperationDto>> GetHistoryAsync(long cardNumber)
    {
        return _mapper.Map<List<OperationDto>>(await _opDao.GetHistoryAsync(cardNumber));
    }

    public async Task LogOperationAsync(long cardNumber, int amount)
    {
        await _opDao.LogOperationAsync(cardNumber, amount);
    }
}
