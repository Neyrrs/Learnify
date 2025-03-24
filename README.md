# Learnify

Learnify adalah aplikasi **booking bimbel online** yang dibangun menggunakan **C# WinForms** dengan database **SQL Server**, dikembangkan menggunakan **Visual Studio 2022**.

## Teknologi yang Digunakan

- **C# WinForms** – Untuk membangun tampilan aplikasi desktop.
- **SQL Server** – Digunakan sebagai database untuk menyimpan data booking dan pengguna.
- **Visual Studio 2022** – Digunakan sebagai IDE utama untuk pengembangan.

## Instalasi & Penggunaan

Ikuti langkah-langkah berikut untuk menjalankan proyek ini secara lokal:

### Prasyarat
- **Visual Studio 2022** dengan workload **.NET Desktop Development**
- **SQL Server** (bisa menggunakan SQL Server Express atau SQL Server Management Studio)
- **.NET Framework** (versi yang sesuai dengan proyek)

### Langkah Instalasi

1. **Clone Repository**
   ```bash
   git clone https://github.com/Neyrrs/Learnify.git
   cd Learnify
   ```
2. **Buka Proyek di Visual Studio**
   - Buka **Visual Studio 2022**
   - Pilih **File > Open > Project/Solution** dan pilih file `.sln`
3. **Konfigurasi Database**
   - Pastikan **SQL Server** berjalan.
   - Ubah **connection string** pada file konfigurasi (misalnya `App.config`) agar sesuai dengan server lokal kamu.
   - Jalankan script SQL (jika ada) untuk membuat tabel yang diperlukan.
4. **Build & Run**
   - Klik **Build Solution** (`Ctrl + Shift + B`)
   - Jalankan aplikasi dengan klik **Start** (`F5`)

## Fitur Utama

- 📌 **Booking Bimbel** – Pengguna dapat melakukan pemesanan bimbingan belajar secara online.
- 📊 **History Bimbel** – Melihat riwayat sesi bimbingan yang sudah dilakukan.
- 🛠️ **Admin Panel** – Mengelola data pengguna dan sesi bimbel.
- ✍️ **CRUD** – Operasi Create, Read, Update, dan Delete untuk data pengguna dan sesi bimbel.

## Lisensi

Proyek ini dilisensikan di bawah **MIT License**. Silakan lihat file `LICENSE` untuk detail lebih lanjut.

---
