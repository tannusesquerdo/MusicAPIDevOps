// MusicController.cs
using Microsoft.AspNetCore.Mvc;
using MusicAPI.DTO;
using MusicAPI.Repository;
using MusicAPI;

[ApiController]
[Route("api/[controller]/[action]")]
public class MusicController : ControllerBase
{
    private readonly MusicRepository _musicRepository;

    public MusicController(MusicRepository musicRepository)
    {
        _musicRepository = musicRepository;
    }


    [HttpGet]
    public async Task<IActionResult> GetAllMusic()
    {
        var allMusic = await _musicRepository.GetAllMusic();
        var musicDtos = allMusic.Select(entity => new MusicDto
        {
            Id = entity.Id,
            Title = entity.Title,
            Artist = entity.Artist,
            S3BucketKey = entity.S3BucketKey,
            // Map other properties as needed
        }).ToList();

        return Ok(musicDtos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetMusicById(string id)
    {
        var music = await _musicRepository.GetMusicById(id);
        if (music == null)
        {
            return NotFound();
        }

        var musicDto = new MusicDto
        {
            Id = music.Id,
            Title = music.Title,
            Artist = music.Artist,
            S3BucketKey = music.S3BucketKey,
            // Map other properties as needed
        };

        return Ok(musicDto);
    }

    [HttpPost]
    public async Task<IActionResult> CreateMusic(MusicDto musicDto)
    {
        var musicEntity = new MusicEntity
        {
            Id = Guid.NewGuid().ToString(), // Generate a unique ID
            Title = musicDto.Title,
            Artist = musicDto.Artist,
            S3BucketKey = musicDto.S3BucketKey,
            // Map other properties as needed
        };

        await _musicRepository.CreateMusic(musicEntity);

        return Ok("Music created successfully");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateMusic(string id, MusicDto musicDto)
    {
        var existingMusic = await _musicRepository.GetMusicById(id);
        if (existingMusic == null)
        {
            return NotFound();
        }

        existingMusic.Title = musicDto.Title;
        existingMusic.Artist = musicDto.Artist;
        existingMusic.S3BucketKey = musicDto.S3BucketKey;
        // Update other properties as needed

        await _musicRepository.UpdateMusic(existingMusic);

        return Ok("Music updated successfully");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMusic(string id)
    {
        await _musicRepository.DeleteMusic(id);

        return Ok("Music deleted successfully");
    }
}
