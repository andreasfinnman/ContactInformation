using Microsoft.AspNetCore.Mvc;
using ContactInformation.Api.Models;
using ContactInformation.Api.Services;
namespace ContactInformation.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ContactInfoController : ControllerBase
{
    private IContactInfoService _service;
    private readonly ILogger<ContactInfoController> _logger;

    public ContactInfoController(IContactInfoService service, ILogger<ContactInfoController> logger)
    {
        _logger = logger;
        _service = service;
    }
    /// <summary>
    /// List all ContactInfo objects
    /// </summary>
    /// <returns>A ContactInfo object</returns>
    [HttpGet(Name = "ListContactInfo")]
    public async Task<List<ContactInfo>> List()
    {
        var result  = await _service.ListContactInfo();
        return result;
    }
    /// <summary>
    /// Retrieves the ContactInfo object specified by the identifier
    /// </summary>
    /// <param name="id">The id of the ContactInfo object </param>
    /// <returns></returns>
    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<ContactInfo>> Get(string id)
    {
        var contactInfo = await _service.GetContactInfo(id);

        if (contactInfo is null)
        {
            return NotFound();
        }

        return contactInfo;
    }

    /// <summary>
    /// Creates a new ContactInfo object. Omit the Id property in the model to have it generated.
    /// This does not update existing. Posting an already existing id will result in error.
    /// NOTE strictly seen this is not a post as it works as an UPDATE rather than an UPSERT
    /// </summary>
    /// <param name="contactInfo"></param>
    /// <returns>The created model</returns>
    [HttpPost]
    public async Task<IActionResult> Post(ContactInfo contactInfo)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await _service.CreateContactInfo(contactInfo);
        return CreatedAtAction(null, new { id = contactInfo.Id }, contactInfo);
    }

    /// <summary>
    /// Makes a replace update of the specified ContactInfo object
    /// </summary>
    /// <param name="id">The id of the object to replace</param>
    /// <param name="contactInfo">The object to replace it with</param>
    /// <returns></returns>
    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, ContactInfo contactInfo)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var retrievedContactInfo = await _service.GetContactInfo(id);

        if (retrievedContactInfo is null)
        {
            return NotFound();
        }

        await _service.UpdateContactInfo(id, contactInfo);

        return NoContent();
    }
    /// <summary>
    /// Deletes the specified ContactInfo object
    /// </summary>
    /// <param name="id">The id of the object to delete</param>
    /// <returns></returns>
    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var contactInfo = await _service.GetContactInfo(id);

        if (contactInfo is null)
        {
            return NotFound();
        }

        return await _service.DeleteContactInfo(id) ? NoContent() : NotFound();
    }
}
