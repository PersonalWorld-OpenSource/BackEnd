using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PersonalWorld.API.Personal.Domain.Models;
using PersonalWorld.API.Personal.Domain.Services;
using PersonalWorld.API.Personal.Resources;
using PersonalWorld.API.Shared.Extensions;

namespace PersonalWorld.API.Personal.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class NotificationsController: ControllerBase
{
    private readonly INotificationService _notificationService;
    private readonly IMapper _mapper;

    public NotificationsController(INotificationService notificationService, IMapper mapper)
    {
        _notificationService = notificationService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<NotificationResource>> GetAllAsync()
    {
        var notifications = await _notificationService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Notification>, IEnumerable<NotificationResource>>(notifications);
        return resources;
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetConsultById(int id)
    {
        var result = await _notificationService.FindByIdAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var resource = _mapper.Map<Notification, NotificationResource>(result.Resource);

        return Ok(resource);
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveNotificationResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var notification = _mapper.Map<SaveNotificationResource, Notification>(resource);

        var result = await _notificationService.SaveAsync(notification);

        if (!result.Success)
            return BadRequest(result.Message);

        var notificationResource = _mapper.Map<Notification, NotificationResource>(result.Resource);

        return Ok(notificationResource);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveNotificationResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var notification = _mapper.Map<SaveNotificationResource,Notification>(resource);

        var result = await _notificationService.UpdateAsync(id,notification);

        if (!result.Success)
            return BadRequest(result.Message);

        var notificationResource = _mapper.Map<Notification, NotificationResource>(result.Resource);

        return Ok(notificationResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _notificationService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var notificationResource = _mapper.Map<Notification, NotificationResource>(result.Resource);

        return Ok(notificationResource);
    }
    
    [HttpGet("api/v1/persons/{id}/[controller]")]
    public async Task<IEnumerable<NotificationResource>> GetAllByPersonIdAsync(int personId)
    {
        var notifications = await _notificationService.ListByPersonIdAsync(personId);
        var resources = _mapper.Map<IEnumerable<Notification>, IEnumerable<NotificationResource>>(notifications);
        return resources;
    }
}