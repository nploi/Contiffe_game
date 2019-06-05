# GAME SHOW
## Sinh viên thực hiện
- Nguyễn Phúc Lợi
- Lê Quang Vinh

### Chức năng
- Streaming video
- Streaming audio
- Gửi câu cho các người chơi
- Thông kê các người chơi đúng nhiều câu nhất sao mỗi câu hỏi
- Phần thưởng người chơi
- Chat


### Hướng dẫn
- Client: [Nuget install](https://www.nuget.org/packages/SocketIoClientDotNet/) for c# client
    ```
    Install-Package SocketIoClientDotNet
    Install-Package Newtonsoft.Json -Version 12.0.2
    ```

- Server: Được viết bằng nodejs và dùng socket io.

    [install node.js](https://nodejs.org/en/)
    and 
    ```
    cd Server
    npm install
    ```