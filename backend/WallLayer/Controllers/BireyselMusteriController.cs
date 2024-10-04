using Microsoft.AspNetCore.Mvc;
using System.Data;
using EntityLayer;
using BusinessLayer;
using Microsoft.AspNetCore.Authorization;

namespace WallLayer.Controllers
{

    // create read update delete ; post get put delete

    [Route("api/[controller]")]
    [ApiController]
    public class BireyselMusteriController : ControllerBase
    {


        // Tüm Müşterileri SQL veritabanından çeker. JSON veri formatında döndürür.
        [HttpGet("tumMusterileriGetir")]
        public IActionResult TumBireyselMusteriGetir() {

            CommonEntityTumMusteriler dtoTum = new CommonEntityTumMusteriler();
            dtoTum.bireyselMusteri = new List<EntityBireyselMusteri>(1);
            dtoTum.irtibatMusteri = new List<EntityIrtibatMusteri>(1);
            dtoTum = BLBireyselMusteri.TumBireyselMusteriGetir();
            
            return Ok(dtoTum);
        }

        //From body ile dto alıp sql veritabanına ekleme işlemi
        [HttpPost("ekle")]
        public IActionResult BMusteriTumBilgileriEkle([FromBody]CommonEntityTumMusteriler dto) 
        { 
           
            int sonuc = BLBireyselMusteri.BMusteriTumBilgileriEkle(dto);
            if (sonuc == 9)
            {
                return Ok("Müşteri başarıyla eklendi.");
            }
            return BadRequest("Müşteri eklenirken hata oluştu.");

        }


        //From body ile dto alıp sql veritabanında güncelleme işlemi
        [HttpPut("guncelle")]
        public IActionResult BMusteriTumBilgileriGuncelle([FromBody]CommonEntityTumMusteriler dto) {

            int sonuc = BLBireyselMusteri.BMusteriTumBilgileriGuncelle(dto);
            if (sonuc == 9)
            {
                return Ok("Müşteri başarıyla güncellendi.");
            }
            return BadRequest("Müşteri güncellenirken hata oluştu.");

        }

        [HttpGet("musteriGetir/{musteriNo}")]
        public IActionResult BireyselMusteriGetir(int musteriNo) {
            
            CommonEntityTumMusteriler dto = new CommonEntityTumMusteriler();
            dto.bireyselMusteri = new List<EntityBireyselMusteri>(1);
            dto.irtibatMusteri = new List<EntityIrtibatMusteri>(1);
            dto = BLBireyselMusteri.BireyselMusteriGetir(musteriNo);

            return Ok(dto);
        }

        [HttpGet("KNOmusteriGetir/{kimlikNo}")]
        public IActionResult KNOBireyselMusteriGetir(string kimlikNo)
        {

            CommonEntityTumMusteriler dto = new CommonEntityTumMusteriler();
            dto.bireyselMusteri = new List<EntityBireyselMusteri>(1);
            dto.irtibatMusteri = new List<EntityIrtibatMusteri>(1);
            dto = BLBireyselMusteri.KNOBireyselMusteriGetir(kimlikNo);

            return Ok(dto);
        }


        [HttpDelete("sil/{musteriNo}")]
        public IActionResult BMusteriPasifeCek(int musteriNo) {

            int sonuc = BLBireyselMusteri.BMusteriPasifeCek(musteriNo);
            if (sonuc == 1)
            {
                return Ok("Müşteri İptal Edildi!");
            }
            return BadRequest("Müşteri güncellenirken hata oluştu.");
        }

        [HttpGet("musteriNoGetir/{tcKimlikNo}")]
        public IActionResult BMusteriNoGetir(string tcKimlikNo) {
            int musteriNo = BLBireyselMusteri.BMusteriNoGetir(tcKimlikNo);
            return Ok(musteriNo);

        }


    }

}
