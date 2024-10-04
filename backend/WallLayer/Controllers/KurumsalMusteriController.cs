using BusinessLayer;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;

namespace WallLayer.Controllers
{
    // create read update delete ; post get put delete

    [Route("api/[controller]")]
    [ApiController]
    public class KurumsalMusteriController : ControllerBase
    {


        // Tüm Müşterileri SQL veritabanından çeker. JSON veri formatında döndürür.
        [HttpGet("tumMusterileriGetir")]
        public IActionResult TumKurumsalMusteriGetir()
        {

            CommonEntityTumMusteriler dtoTum = new CommonEntityTumMusteriler();
            dtoTum.kurumsalMusteri = new List<EntityKurumsalMusteri>(1);
            dtoTum.irtibatMusteri = new List<EntityIrtibatMusteri>(1);
            dtoTum = BLKurumsalMusteri.TumKurumsalMusteriGetir();

            return Ok(dtoTum);
        }

        //From body ile dto alıp sql veritabanına ekleme işlemi
        [HttpPost("ekle")]
        public IActionResult KMusteriTumBilgileriEkle([FromBody] CommonEntityTumMusteriler dto)
        {

            int sonuc = BLKurumsalMusteri.KMusteriTumBilgileriEkle(dto);
            if (sonuc == 10)
            {
                return Ok("Müşteri başarıyla eklendi.");
            }
            return BadRequest("Müşteri eklenirken hata oluştu.");

        }


        //From body ile dto alıp sql veritabanında güncelleme işlemi
        [HttpPut("guncelle")]
        public IActionResult KMusteriTumBilgileriGuncelle([FromBody] CommonEntityTumMusteriler dto)
        {

            int sonuc = BLKurumsalMusteri.KMusteriTumBilgileriGuncelle(dto);
            if (sonuc == 10)
            {
                return Ok("Müşteri başarıyla güncellendi.");
            }
            return BadRequest("Müşteri güncellenirken hata oluştu.");

        }

        [HttpGet("musteriGetir/{musteriNo}")]
        public IActionResult KurumsalMusteriGetir(int musteriNo)
        {

            CommonEntityTumMusteriler dto = new CommonEntityTumMusteriler();
            dto.kurumsalMusteri = new List<EntityKurumsalMusteri>(1);
            dto.irtibatMusteri = new List<EntityIrtibatMusteri>(1);
            dto = BLKurumsalMusteri.KurumsalMusteriGetir(musteriNo);

            return Ok(dto);
        }

        [HttpGet("KNOmusteriGetir/{kimlikNo}")]
        public IActionResult KNOKurumsalMusteriGetir(string kimlikNo)
        {

            CommonEntityTumMusteriler dto = new CommonEntityTumMusteriler();
            dto.kurumsalMusteri = new List<EntityKurumsalMusteri>(1);
            dto.irtibatMusteri = new List<EntityIrtibatMusteri>(1);
            dto = BLKurumsalMusteri.KNOKurumsalMusteriGetir(kimlikNo);

            return Ok(dto);
        }

        [HttpDelete("sil/{musteriNo}")]
        public IActionResult KMusteriPasifeCek(int musteriNo)
        {

            int sonuc = BLKurumsalMusteri.KMusteriPasifeCek(musteriNo);
            if (sonuc == 1)
            {
                return Ok("Müşteri İptal Edildi!");
            }
            return BadRequest("Müşteri güncellenirken hata oluştu.");
        }

        [HttpGet("musteriNoGetir/{vergiKimlikNo}")]
        public IActionResult KMusteriNoGetir(string vergiKimlikNo)
        {
            int musteriNo = BLKurumsalMusteri.KMusteriNoGetir(vergiKimlikNo);
            return Ok(musteriNo);

        }


    }
}
