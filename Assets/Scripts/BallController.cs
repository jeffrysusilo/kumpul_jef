using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BallController : MonoBehaviour {
    public int force;
    int scoreP1;
    int scoreP2;
    Rigidbody2D rigid;
    TextMeshProUGUI scoreUIP1;
    TextMeshProUGUI scoreUIP2;
    TextMeshProUGUI scoreUIP3;
    TextMeshProUGUI scoreUIP4;
    GameObject panelSelesai;
    TextMeshProUGUI txPemenang;


    void Start () {
        rigid = GetComponent<Rigidbody2D>();
        Vector2 arah = new Vector2(0, 2).normalized; // Mengubah arah menjadi (0, 2) untuk bergerak ke atas
        rigid.AddForce(arah * force);
        scoreP1 = 0;
        scoreP2 = 0;
        scoreUIP1 = GameObject.Find ("skorBiruAtas").GetComponent<TextMeshProUGUI> ();
        scoreUIP2 = GameObject.Find ("skorMerahAtas").GetComponent<TextMeshProUGUI> ();
        scoreUIP3 = GameObject.Find ("skorBiruBawah").GetComponent<TextMeshProUGUI> ();
        scoreUIP4 = GameObject.Find ("skorMerahBawah").GetComponent<TextMeshProUGUI> ();

        panelSelesai = GameObject.Find ("PanelSelesai");
        panelSelesai.SetActive (false);

    }

    void Update () {
    }

    private void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.name == "gawangBiru") {
            scoreP2 += 1;
            ResetBall();
            Vector2 arah = new Vector2(0, 2).normalized; // Mengubah arah menjadi (0, 2) untuk bergerak ke atas
            rigid.AddForce(arah * force);
            TampilkanScore();
            if (scoreP2 == 5) {
                panelSelesai.SetActive (true);
                txPemenang = GameObject.Find ("Pemenang").GetComponent<TextMeshProUGUI> ();
                txPemenang.text = "Merah Win";
                Destroy (gameObject);
                return;}
            }

        if (coll.gameObject.name == "gawangMerah") {
            scoreP1 += 1;
            ResetBall();
            Vector2 arah = new Vector2(0, -2).normalized; // Mengubah arah menjadi (0, -2) untuk bergerak ke bawah
            rigid.AddForce(arah * force);
            TampilkanScore();
            if (scoreP1 == 5) {
                panelSelesai.SetActive (true);
                txPemenang = GameObject.Find ("Pemenang").GetComponent<TextMeshProUGUI> ();
                txPemenang.text = "Biru Win";
                Destroy (gameObject);
                return;
            }

        }

        if (coll.gameObject.name == "Pemukul1" || coll.gameObject.name == "Pemukul2") {
            float sudut = (transform.position.y - coll.transform.position.y) * 5f;
            Vector2 arah = new Vector2(rigid.velocity.x, sudut).normalized;
            rigid.velocity = new Vector2(0, 0);
            rigid.AddForce(arah * force * 2);
        }
    }

    void ResetBall() {
        transform.localPosition = new Vector2(0, 0);
        rigid.velocity = new Vector2(0, 0);
    }

    void TampilkanScore () {
        Debug.Log ("Score P1: " + scoreP1 + " Score P2: " + scoreP2);
        scoreUIP1.text = scoreP1.ToString(); // Mengonversi scoreP1 ke string
        scoreUIP2.text = scoreP2.ToString(); // Mengonversi scoreP2 ke string
        scoreUIP3.text = scoreP1.ToString(); // Mengonversi scoreP1 ke string
        scoreUIP4.text = scoreP2.ToString(); // Mengonversi scoreP2 ke string
    }
}
