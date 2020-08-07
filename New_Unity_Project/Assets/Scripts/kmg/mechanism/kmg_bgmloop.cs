// 사용된 브금의 원래 모듈 파일 출처는 아래와 같습니다
// https://modarchive.org/index.php?request=view_by_moduleid&query=117922
// 링크 타고 들어간 후 'Play with Online Player'를 클릭해서 재생할 수 있습니다

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kmg_bgmloop : MonoBehaviour
{
	AudioSource bgm;
	
	// 원래 모듈 파일의 구간반복 지점을 그대로 재현하기 위함
	int loopStart = 1016064, loopEnd = 3556223;
	
	// Start is called before the first frame update
	void Start()
	{
		bgm = gameObject.GetComponent<AudioSource>();
		bgm.Play();
	}
	
	// Update is called once per frame
	void Update()
	{
		if(bgm.timeSamples >= loopEnd)
			bgm.timeSamples = loopStart;
	}
}
