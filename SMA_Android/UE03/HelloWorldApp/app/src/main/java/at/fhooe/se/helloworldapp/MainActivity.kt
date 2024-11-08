package at.fhooe.se.helloworldapp

import android.os.Bundle
import android.util.Log
import androidx.appcompat.app.AppCompatActivity

private const val TAG = "MainActivity"

class MainActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        Log.d(TAG, "onCreate() called")
    }

    override fun onStart() {
        super.onStart();

        Log.e(TAG, "onStart() called")
    }

    override fun onResume() {
        super.onResume();

        Log.i(TAG, "onResume() called")
    }

    override fun onPause() {
        super.onPause();

        Log.w(TAG, "onPause() called")
    }

    override fun onStop() {
        super.onStop();

        Log.d(TAG, "onStop() called")
    }

    override fun onDestroy() {
        super.onDestroy();

        Log.d(TAG, "onDestroy() called")
    }

    override fun onRestart() {
        super.onRestart();

        Log.d(TAG, "onRestart() called")
    }

}