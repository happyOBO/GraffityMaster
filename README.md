## GraffityMaster


### 21-11-28

- 1인칭 플레이어 컨트롤러 생성
- ToDo
  - 텍스처에 픽셀값을 변경하는 식으로 진행할건데,
  - 카메라로부터 나오는 레이캐스트의 position 값을 이용해서
  - Wall 의 어느 비율에 있는지를 체크해서 해당 픽셀 값 조정하는 방식으로 진행해보자.
  - [Texture2D.GetPixel](https://docs.unity3d.com/kr/530/ScriptReference/Texture2D.GetPixel.html)
  - [Texture2D.SetPixel](https://docs.unity3d.com/kr/530/ScriptReference/Texture2D.SetPixel.html)


### 21-12-06

- 텍스처 픽셀 값 변경하는 방법 확인
- [Texture2D.GetPixel](https://docs.unity3d.com/kr/530/ScriptReference/Texture2D.GetPixel.html)
- [Texture2D.SetPixel](https://docs.unity3d.com/kr/530/ScriptReference/Texture2D.SetPixel.html)

### 21-12-12

- 매테리얼 내 텍스처 변경하는 방법 확인 : [Material.SetTexture](https://docs.unity3d.com/kr/530/ScriptReference/Material.SetTexture.html)
- 빈 텍스처 생성후 [Texture2D.SetPixel](https://docs.unity3d.com/kr/530/ScriptReference/Texture2D.SetPixel.html) 을 이용해서 일부 텍스처만 변경되게끔 
- RayCast를 현재 메인 카메라 방향으로 쏘아서, 벽의 어디 좌표에 hit 포인트 확인하여, 픽셀 위치와 매핑



### 21-12-13

- `PaletteUI` 생성
- 플레이시 변경될 텍스쳐는 Dictionary로 관리
- 색 추가
- CG 쉐이더에서 `lerp`를 이용해서 해당 스프레이 지점으로 마스크 효과