using System.Collections.Generic;

// TODO: SyncSet - statc 클래스로 만들기
// TODO: 생성자, 멤버 변수로 설정한 SyncSet 코드들 수정하기
struct SyncSet
{
    //Input
    public HashSet<IInputable> newInputs;
    public HashSet<IInputable> deleteInputs;

    //Render
    public HashSet<Renderer> newRenderers;
    public HashSet<Renderer> deleteRenderers;
}